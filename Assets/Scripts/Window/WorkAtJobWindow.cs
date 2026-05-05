using UnityEngine;
using UnityEngine.UI;
public class WorkAtJobWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject workAtJobWindow;
    [SerializeField]
    private FindJobWindow findJobWindowScript;
    [SerializeField]
    private Button jobButton;
    private void Start()
    {
        Close();
    }
    public void Show()
    {
        workAtJobWindow.SetActive(true);
    }
    public void Close()
    {
        workAtJobWindow.SetActive(false);
    }
    public void Work()
    {
        HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID).AddMoney(
        JobManager.Instance.GetJobFromID(HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID).JobID).Pay
        );
    }
    public void QuitJob()
    {
        HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID).SetJob("");
        jobButton.onClick.RemoveAllListeners();
        jobButton.onClick.AddListener(() => findJobWindowScript.Show());
        Close();
    }
}