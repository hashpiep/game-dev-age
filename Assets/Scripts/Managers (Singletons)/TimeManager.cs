using System;
using UnityEngine;
public class TimeManager : MonoBehaviour
{
    private int year = 1970;
    private int month = 1;
    private int day = 1;
    private int hour = 7;
    private int minute = 0;
    private int dayOfTheWeek = 1;
    public string Date { get { return $"{month}.{day}. {year} {hour}:{((minute < 10) ? 0 : "")}{minute} {DayOfTheWeek}"; } }
    public string DayOfTheWeek { get
        {
            switch (dayOfTheWeek)
            {
                case 1:
                    return "Monday";
                case 2:
                    return "Tuesday";
                case 3:
                    return "Wednesday";
                case 4:
                    return "Thursday";
                case 5:
                    return "Friday";
                case 6:
                    return "Saturday";
                case 7:
                    return "Sunday";
                default:
                    return "Monday";
            }
        } }
    public event Action OnTimeChanged;
    private static TimeManager instance;
    public static TimeManager Instance { get { return instance; } }
    private void Start()
    {
        instance = this;
    }
    public void PassTimeInMinutes(int minutes)
    {
        AddMinutes(minutes);
        OnTimeChanged?.Invoke();
    }
    public void PassTimeInHours(int hours)
    {
        AddHours(hours);
        OnTimeChanged?.Invoke();
    }
    public void PassTimeInHoursAndMinutes(int minutes, int hours)
    {
        AddMinutes(minutes);
        AddHours(hours);
        OnTimeChanged?.Invoke();
    }
    private void AddMinutes(int minutesAdded)
    {
        minute += minutesAdded;

        while (minute > 59)
        {
            minute -= 60;
            AddHours(1);
        }
    }
    private void AddHours(int hoursAdded)
    {
        hour += hoursAdded;

        while (hour > 23)
        {
            hour -= 24;
            AddDays(1);
        }
    }
    private void AddDays(int daysAdded)
    {
        day += daysAdded;
        dayOfTheWeek += daysAdded;

        while (dayOfTheWeek > 7)
        {
            dayOfTheWeek -= 7;
        }

        while (day > 30)
        {
            day -= 30;
            AddMonths(1);
        }
    }
    private void AddMonths(int monthsAdded)
    {
        month += monthsAdded;

        while (month > 12)
        {
            month -= 12;
            AddYears(1);
        }
    }
    private void AddYears(int yearsAdded)
    {
        year += yearsAdded;
    }
}