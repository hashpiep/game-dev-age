using TMPro;
using UnityEngine;
public class MoneyLabel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text label;
    public void Init()
    {
        HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID).OnMoneyChanged += UpdateUI;
        UpdateUI(HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID).Money);
    }
    public void UpdateUI(float money)
    {
        label.text = $"{money}$ - {HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID).Info.FirstName}";
    }
}