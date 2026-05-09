using TMPro;
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
    [SerializeField]
    private TMP_Text shiftInfoLabel;
    private void Start()
    {
        Close();
    }
    public void Show()
    {
        workAtJobWindow.SetActive(true);
        UpdateShiftInfo();
    }
    private void UpdateShiftInfo()
    {
        Human human = HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID);
        Job job = JobManager.Instance.GetJobFromID(human.JobID);
        Shift shift = job.Shift;

        shiftInfoLabel.text = $"{shift.StartHour}:{((shift.StartMinute < 10) ? "0" : "")}{shift.StartMinute}-{shift.EndHour}:{((shift.EndMinute < 10) ? "0" : "")}{shift.EndMinute} on: \n";

        for (int i = 0; i < shift.WorkDays.Count; i++)
        {
            string workDay = "";

            switch(shift.WorkDays[i])
            {
                case 1:
                    workDay = "Monday";
                    break;
                case 2:
                    workDay = "Tuesday";
                    break;
                case 3:
                    workDay = "Wednesday";
                    break;
                case 4:
                    workDay = "Thursday";
                    break;
                case 5:
                    workDay = "Friday";
                    break;
                case 6:
                    workDay = "Saturday";
                    break;
                case 7:
                    workDay = "Sunday";
                    break;
            }

            shiftInfoLabel.text += workDay;

            if (i != shift.WorkDays.Count - 1)
                shiftInfoLabel.text += ", ";
        }
    }
    public void Close()
    {
        workAtJobWindow.SetActive(false);
    }
    public void Work()
    {
        Human human = HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID);
        Job job = JobManager.Instance.GetJobFromID(human.JobID);
        Shift shift = job.Shift;
        int currentHour = TimeManager.Instance.Hour;
        int currentMinute = TimeManager.Instance.Minute;

        if (!shift.WorkDays.Contains(TimeManager.Instance.DayOfTheWeekInt))
            return;

        if (shift.StartHour <= currentHour && shift.EndHour > currentHour && shift.StartMinute <= currentMinute)
        {
            int hoursWorked = shift.EndHour - shift.StartHour + (shift.StartHour - currentHour);
            TimeManager.Instance.PassTimeInHoursAndMinutes(shift.EndMinute - shift.StartMinute + (shift.StartMinute - currentMinute), hoursWorked);
            human.AddMoney(job.PayPerHour * hoursWorked);
            Close();
        }
        else
            return;
    }
    public void QuitJob()
    {
        HumanManager.Instance.GetHumanFromID(HumanManager.Instance.PlayerID).SetJob("");
        jobButton.onClick.RemoveAllListeners();
        jobButton.onClick.AddListener(() => findJobWindowScript.Show());
        Close();
    }
}