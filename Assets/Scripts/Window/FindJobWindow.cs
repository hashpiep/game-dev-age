using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FindJobWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject findJobWindow;
    [SerializeField]
    private JobPrefab jobPrefab;
    [SerializeField]
    private Transform container;
    [SerializeField]
    private Button jobButton;
    [SerializeField]
    private WorkAtJobWindow workAtJobWindowScript;
    private void Start()
    {
        Close();
        jobButton.onClick.AddListener(() => Show());
    }
    public void Close()
    {
        findJobWindow.SetActive(false);
    }
    public void Show()
    {
        findJobWindow.SetActive(true);
        GenerateJobs();
    }
    private void GenerateJobs()
    {
        Extensions.KillAllChildrenOfParent(container);

        List<Job> jobs = JobManager.Instance.GetJobs();

        foreach (Job job in jobs)
        {
            var obj = Instantiate(jobPrefab, container);
            string name = $"{job.Name} - {job.PayPerHour}$ per hour";
            obj.Init(name, () =>
            {
                HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID).SetJob(job.ID);
                jobButton.onClick.RemoveAllListeners();
                jobButton.onClick.AddListener(() => workAtJobWindowScript.Show());
                Close();
            });
        }
    }
}