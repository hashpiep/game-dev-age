using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToolPrefab : MonoBehaviour
{
    [SerializeField]
    private TMP_Text label;
    [SerializeField]
    private Button btn;
    public void UpdateUI(string labelText, UnityAction action)
    {
        label.text = labelText;
        btn.onClick.AddListener(action);
    }
}
