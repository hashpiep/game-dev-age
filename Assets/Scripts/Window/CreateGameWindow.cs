using TMPro;
using UnityEngine;
public class CreateGameWindow : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameObject createGameWindow;
    [SerializeField]
    private TMP_InputField nameInputField;
    public void CreateGame()
    {
        if (nameInputField.text == null || nameInputField.text == "")
        {
            return;
        }

        gameManager.CreateGame(nameInputField.text);
        nameInputField.text = "";
        Close();
    }
    public void Close()
    {
        createGameWindow.SetActive(false);
    }
    public void Show()
    {
        createGameWindow.SetActive(true);
    }
}