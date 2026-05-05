using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class CreateGameWindowPCOrOSDisplayPrefab : MonoBehaviour
{
    [SerializeField]
    private TMP_Text label;
    [SerializeField]
    private Button button;
    public void Init(string labelText, UnityAction action)
    {
        label.text = labelText;
        button.onClick.AddListener(action);
    }
}