using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CreateGameWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject createGameWindow;
    [SerializeField]
    private TMP_InputField nameInputField;
    [Header("Containers")]
    [SerializeField]
    private Transform programmingLanguagesContainer;
    [SerializeField]
    private Transform pcAndOSContainer;
    [Header("Prefabs")]
    [SerializeField]
    private CreateGameWindowProgLangBtnPrefab progLangBtnPrefab;
    [SerializeField]
    private CreateGameWindowPCOrOSDisplayPrefab pCOrOSDisplayPrefab;
    [Header("Other Window Scripts")]
    [SerializeField]
    private GamesWindow gamesWindow;
    private string chosenProgLangID;
    private string chosenGamePlatID;
    private void Start()
    {
        Close();
    }
    private void GenerateProgrammingLanguages(GamingPlatform platform)
    {
        Extensions.KillAllChildrenOfParent(programmingLanguagesContainer);

        List<ProgrammingLanguage> progLangs = ProgrammingLanguageManager.Instance.GetProgLanguages();

        foreach (ProgrammingLanguage language in progLangs)
        {
            if (!language.Properties.SupportedGamingPlatformsIDs.Contains(platform.ID)) 
                continue;

            var obj = Instantiate(progLangBtnPrefab, programmingLanguagesContainer);
            obj.Init(language.Name, () =>
            {
                chosenProgLangID = language.ID;
            });
        }
    }
    private void GeneratePlatforms()
    {
        chosenGamePlatID = null;
        chosenProgLangID = null;

        Extensions.KillAllChildrenOfParent(pcAndOSContainer);

        List<GamingPlatform> gamingPlatforms = GamingPlatformManager.Instance.GetGamingPlatforms();

        foreach (GamingPlatform platform in gamingPlatforms)
        {
            var obj = Instantiate(pCOrOSDisplayPrefab, pcAndOSContainer);
            obj.Init(platform.Name, () =>
            {
                chosenProgLangID = null;
                GenerateProgrammingLanguages(platform);
                chosenGamePlatID = platform.ID;
            });
        }
    }
    private void GenerateItems()
    {
        GeneratePlatforms();
    }
    public void CreateGame()
    {
        if (nameInputField.text == null || nameInputField.text == "" || chosenGamePlatID == null || chosenProgLangID == null)
        {
            return;
        }

        GameManager.Instance.CreateGame(nameInputField.text, chosenProgLangID, HumanManager.Instance.PlayerID, chosenGamePlatID);
        nameInputField.text = "";
        Close();
        gamesWindow.Show();
    }
    public void Close()
    {
        createGameWindow.SetActive(false);
    }
    public void Show()
    {
        createGameWindow.SetActive(true);
        GenerateItems();
        nameInputField.text = "";
    }
}