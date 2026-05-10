using UnityEngine;
public class SkillsWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject skillsWindow;
    [SerializeField]
    private Transform container;
    [SerializeField]
    private SkillPrefab skillPrefab;
    private void Start()
    {
        Close();
    }
    public void Close()
    {
        skillsWindow.SetActive(false);
    }
    public void Show()
    {
        skillsWindow.SetActive(true);
        GenerateSkills();
    }
    private void GenerateSkills()
    {
        Extensions.KillAllChildrenOfParent(container);

        Human player = HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID);

        foreach (Skill skill in player.Skills.Values)
        {
            var obj = Instantiate(skillPrefab, container);
            obj.UpdateUI($"{skill.DisplayName} - {skill.Progress}/{skill.MaxProgress}");
        }
    }
}
