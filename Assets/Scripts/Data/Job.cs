public class Job
{
    private string id;
    private string name;
    private float payPerHour;
    private Shift shift;
    public string ID { get { return id; } }
    public string Name { get { return name; } }
    public float PayPerHour { get { return payPerHour; } }
    public Shift Shift { get { return shift; } }
    public Job(string id, string name, float payPerHour, Shift shift) 
    { 
        this.id = id;
        this.name = name;
        this.payPerHour = payPerHour;
        this.shift = shift;
    }
}