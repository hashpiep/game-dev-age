using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ToolsWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject toolsWindow;
    [SerializeField]
    private Transform container;
    [SerializeField]
    private ToolPrefab toolPrefab;
    [SerializeField]
    private TMP_Text toolInfoLabel;
    private void Start()
    {
        Close();
    }
    public void Close()
    {
        toolsWindow.SetActive(false);
    }
    public void Show()
    {
        toolsWindow.SetActive(true);
        GenerateMyTools();
        toolInfoLabel.text = "";
    }
    public void GenerateMyTools()
    {
        Extensions.KillAllChildrenOfParent(container);

        List<ProgrammingLanguage> programmingLanguages = ProgrammingLanguageManager.Instance.GetProgLanguagesOfAuthorID(HumanManager.Instance.PlayerID);

        foreach (var progLang in programmingLanguages)
        {
            var obj = Instantiate(toolPrefab, container);
            obj.UpdateUI($"{progLang.Name} (Programming Language)", () => ShowProgLangInfo(progLang));
        }
    }
    public void GenerateProgLanguages()
    {
        Extensions.KillAllChildrenOfParent(container);

        List<ProgrammingLanguage> programmingLanguages = ProgrammingLanguageManager.Instance.GetProgLanguages();

        foreach(var progLang in programmingLanguages)
        {
            var obj = Instantiate(toolPrefab, container);
            obj.UpdateUI($"{progLang.Name}", () => ShowProgLangInfo(progLang));
        }
    }
    private void ShowProgLangInfo(ProgrammingLanguage progLang)
    {
        Human author = HumanManager.Instance.GetHumanFromID(progLang.AuthorID);

        toolInfoLabel.text = $"{progLang.Name} made by {author.Info.FirstName} {author.Info.LastName}";
    }
}