public class TechEntity : Entity
{
    private WorldTimestamp releaseDate;
    private string name;
    public WorldTimestamp ReleaseDate { get { return releaseDate; } }
    public string Name { get { return name; } }
    public TechEntity(string id, string name, WorldTimestamp releaseDate) : base(id)
    {
        this.releaseDate = releaseDate;
        this.name = name;
    }
}