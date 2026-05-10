using TMPro;
using UnityEngine;
public class SkillPrefab : MonoBehaviour
{
    [SerializeField]
    private TMP_Text label;
    public void UpdateUI(string labelText)
    {
        label.text = labelText;
    }
}