using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WorkOnGameWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject workOnGameWindow;
    [SerializeField]
    private GameSelectionPrefab gameSelectionPrefab;
    [SerializeField]
    private GameObject gameSelectionWindow;
    [SerializeField]
    private GameObject workTypeWindow;
    [SerializeField]
    private Button workOnSelectedGameBtn;
    [SerializeField]
    private Transform gameSelectionContainer;
    private void Start()
    {
        Close();
    }
    public void Close()
    {
        HideGameSelection();
        HideWorkType();
        Hide();
    }
    public void Show()
    {
        workOnGameWindow.SetActive(true);
        ShowGameSelection();
        HideWorkType();
        GenerateGameSelectionList();
    }
    private void GenerateGameSelectionList()
    {
        List<Game> games = GameManager.Instance.GetGamesMadeByAuthorID(HumanManager.Instance.PlayerID);

        Extensions.KillAllChildrenOfParent(gameSelectionContainer);

        foreach (Game game in games)
        {
            if (game.IsFinished)
                continue;

            GameSelectionPrefab prefab = Instantiate(gameSelectionPrefab, gameSelectionContainer);
            prefab.ChangeGameNameLabelTo(game.Name);
            prefab.AddWorkOnButtonPress(() =>
            {
                ShowWorkType(game);
                HideGameSelection();
            });
        }
    }
    private void ShowWorkType(Game game)
    {
        workTypeWindow.SetActive(true);
        workOnSelectedGameBtn.onClick.RemoveAllListeners();
        workOnSelectedGameBtn.onClick.AddListener(() =>
        {
            game.AddProgress(5);
            TimeManager.Instance.PassTimeInHoursAndMinutes(30, 2);

            if (game.IsFinished)
                Show();
        });
    }
    private void ShowGameSelection()
    {
        gameSelectionWindow.SetActive(true);
    }
    private void HideGameSelection()
    {
        gameSelectionWindow.SetActive(false);
    }
    private void HideWorkType()
    {
        workTypeWindow.SetActive(false);
    }
    private void Hide()
    {
        workOnGameWindow.SetActive(false);
    }
}