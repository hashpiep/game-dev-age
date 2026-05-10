public class Game
{
    private string id;
    private string name;
    private string authorID;
    private string programmingLanguageID;
    private string gamingPlatformID;
    private float progress = 0;
    private float maxProgress = 100;
    private ProductState state;
    public ProductState State { get { return state; } }
    public string ID { get { return id; } }
    public string Name { get { return name; } }
    public string AuthorID { get { return authorID; } }
    public string ProgrammingLanguageID { get { return programmingLanguageID; } }
    public string GamingPlatformID { get { return gamingPlatformID; } }
    public bool IsFinished { get { return progress >= maxProgress; } }
    public Game(string id, string name, string authorID, string programmingLanguageID, string gamingPlatformID, ProductState state)
    {
        this.id = id;
        this.name = name;
        this.authorID = authorID;
        this.programmingLanguageID = programmingLanguageID;
        this.gamingPlatformID = gamingPlatformID;
        this.state = state;
    }
    public void AddProgress(float howMuch)
    {
        progress += howMuch;

        if (progress > maxProgress)
            progress = maxProgress;
    }
    public void Release()
    {
        state = ProductState.Released;
    }
}
public enum ProductState 
{ 
    InDevelopment,
    Cancelled,
    Released,
}