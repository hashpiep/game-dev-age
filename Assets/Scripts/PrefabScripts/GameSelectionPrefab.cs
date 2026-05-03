using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class GameSelectionPrefab : MonoBehaviour
{
    [SerializeField]
    private TMP_Text gameNameLabel;
    [SerializeField]
    private Button workOnBtn;
    public void AddWorkOnButtonPress(UnityAction action)
    {
        workOnBtn.onClick.RemoveAllListeners();
        workOnBtn.onClick.AddListener(action);
    }
    public void ChangeGameNameLabelTo(string text)
    {
        gameNameLabel.text = text;
    }
}