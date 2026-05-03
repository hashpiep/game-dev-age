public class WorldTimestamp
{
    private int year;
    private int month;
    private int day;
    private int hour;
    private int minute;
    public string FullDate { get { return $"{day}.{month} {year} {hour}:{minute}"; } }
    public WorldTimestamp(int year, int month, int day, int hour, int minute)
    {
        this.year = year;
        this.month = month;
        this.day = day;
        this.hour = hour;
        this.minute = minute;
    }
}