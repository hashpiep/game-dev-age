using TMPro;
using UnityEngine;
public class TimeLabel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text label;
    public void Init()
    {
        TimeManager.Instance.OnTimeChanged += UpdateUI;
        UpdateUI();
    }
    public void UpdateUI()
    {
        label.text = TimeManager.Instance.Date;
    }
}