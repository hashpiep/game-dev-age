using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BookshelfWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject bookshelfWindow;
    [SerializeField]
    private Transform container;
    [SerializeField]
    private StartBookPrefab startBookPrefab;
    [SerializeField]
    private BookPrefab bookPrefab;
    [Header("Info")]
    [SerializeField]
    private TMP_Text infoLabel;
    [SerializeField]
    private Button readBtn;
    [SerializeField]
    private Button buyBtn;
    private void Start()
    {
        Close();
    }
    public void Close()
    {
        bookshelfWindow.SetActive(false);
    }
    public void Show()
    {
        bookshelfWindow.SetActive(true);

        infoLabel.text = "";
        readBtn.gameObject.SetActive(false);
        buyBtn.gameObject.SetActive(false);

        GenerateBoughtBooks();
    }
    public void GenerateBoughtBooks()
    {
        Extensions.KillAllChildrenOfParent(container);

        Human human = HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID);
        List<string> bookIDs = human.BoughtBooksIDs;
        List<Book> books = BookManager.Instance.GetBooksFromIDs(bookIDs);

        foreach (Book book in books)
        {
            var obj = Instantiate(bookPrefab, container);
            obj.UpdateUI($"{book.Name}", () => SelectBookForReading(book));
        }
    }
    public void GenerateNonboughtBooks()
    {
        Extensions.KillAllChildrenOfParent(container);

        Human human = HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID);
        List<string> bookIDs = human.BoughtBooksIDs;
        List<Book> boughtBooks = BookManager.Instance.GetBooksFromIDs(bookIDs);
        List<Book> allBooks = BookManager.Instance.GetBooks();
        List<Book> unownedBooks = new List<Book>();

        foreach (Book book in allBooks)
        {
            bool doesHave = false;

            foreach (Book boughtBook in boughtBooks)
            {
                if (book.ID == boughtBook.ID)
                {
                    doesHave = true;
                    break;
                }
            }

            if (!doesHave)
                unownedBooks.Add(book);
        }

        foreach (Book book in unownedBooks)
        {
            var obj = Instantiate(bookPrefab, container);
            obj.UpdateUI($"{book.Name} ({book.Price}$)", () => SelectBookForBuying(book));
        }
    }
    public void GenerateMyBooks()
    {
        Extensions.KillAllChildrenOfParent(container);

        List<Book> books = BookManager.Instance.GetBooksFromAuthorID(HumanManager.Instance.PlayerID);

        foreach (Book book in books)
        {
            var obj = Instantiate(bookPrefab, container);
            obj.UpdateUI($"{book.Name}", () => SelectBookForReading(book));
        }
    }
    private void SelectBookForBuying(Book book)
    {
        Human author = HumanManager.Instance.GetHumanFromID(book.AuthorID);
        HumanInfo info = author.Info;

        infoLabel.text = $"{book.Name} by {info.FirstName} {info.LastName} - {book.Price}$";
        readBtn.gameObject.SetActive(false);
        buyBtn.gameObject.SetActive(true);

        buyBtn.onClick.RemoveAllListeners();
        buyBtn.onClick.AddListener(() =>
        {
            Human player = HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID);

            if (player.Money < book.Price)
                return;

            player.RemoveMoney(book.Price);
            player.BoughtBooksIDs.Add(book.ID);
            infoLabel.text = "";
            readBtn.gameObject.SetActive(false);
            buyBtn.gameObject.SetActive(false);
            GenerateNonboughtBooks();
        });
    }
    private void SelectBookForReading(Book book)
    {
        Human author = HumanManager.Instance.GetHumanFromID(book.AuthorID);
        HumanInfo info = author.Info;

        infoLabel.text = $"{book.Name} by {info.FirstName} {info.LastName}";
        readBtn.gameObject.SetActive(true);
        buyBtn.gameObject.SetActive(false);

        readBtn.onClick.RemoveAllListeners();
        readBtn.onClick.AddListener(() =>
        {
            TimeManager.Instance.PassTimeInHoursAndMinutes(1, 30);

            Human player = HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID);
            ProgrammingLanguage progLang = ProgrammingLanguageManager.Instance.GetProgLanguageFromID(book.SkillKey);

            player.IncreaseSkill(book.SkillKey, 1.5f, new Skill($"{progLang.Name}", "Programming Languages", 100, 10));
        });
    }
}