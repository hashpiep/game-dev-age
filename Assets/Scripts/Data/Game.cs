public class Game : TechEntity
{
    private string authorId;
    private float progress = 0;
    private float maxProgress = 100;
    private GameState state;
    public GameState State { get { return state; } }
    public string AuthorID { get { return authorId; } }
    public bool IsFinished { get { return progress >= maxProgress; } }
    public Game(string id, string name, WorldTimestamp releaseDate, string authorId, GameState state) : base(id, name, releaseDate)
    {
        this.authorId = authorId;
        this.state = state;
    }
    public void AddProgress(float howMuch)
    {
        progress += howMuch;

        if (progress > maxProgress)
            progress = maxProgress;
    }
}
public enum GameState 
{ 
    InDevelopment,
    Cancelled,
    Released,
}