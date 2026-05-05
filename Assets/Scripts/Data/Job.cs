public class Job
{
    private string id;
    private string name;
    private float pay;
    public string ID { get { return id; } }
    public string Name { get { return name; } }
    public float Pay { get { return pay; } }
    public Job(string id, string name, float pay) 
    { 
        this.id = id;
        this.name = name;
        this.pay = pay;
    }
}