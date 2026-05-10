using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamePrefab : MonoBehaviour
{
    [SerializeField]
    private TMP_Text label;
    [SerializeField]
    private Button button;
    public void UpdateUI(string labelText, UnityAction action)
    {
        label.text = labelText;
        button.onClick.AddListener(action);
    }
}
