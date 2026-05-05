using System.Collections.Generic;
public class Shift
{
    private List<int> workDays;
    private int startHour;
    private int startMinute;
    private int endHour;
    private int endMinute;
    public List<int> WorkDays { get { return workDays; } }
    public int StartHour { get { return startHour; } }
    public int StartMinute { get { return startMinute; } }
    public int EndHour { get { return endHour; } }
    public int EndMinute { get { return endMinute; } }
    public Shift(List<int> workDays, int startHour, int startMinute, int endHour, int endMinute)
    {
        this.workDays = workDays;
        this.startHour = startHour;
        this.startMinute = startMinute;
        this.endHour = endHour;
        this.endMinute = endMinute;
    }
}