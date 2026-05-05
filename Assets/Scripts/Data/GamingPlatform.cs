public class GamingPlatform
{
    private string id;
    private string name;
    public string ID { get { return id; } }
    public string Name { get { return name; } }
    public GamingPlatform(string id, string name)
    {
        this.id = id;
        this.name = name;
    }
}