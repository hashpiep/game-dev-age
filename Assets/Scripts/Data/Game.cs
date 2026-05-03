public class Game
{
    private string name;
    private string authorId;
    private float progress = 0;
    private float maxProgress = 100;
    private GameState state;
    public string Name { get { return name; } }
    public GameState State { get { return state; } }
    public string AuthorID { get { return authorId; } }
    public bool IsFinished { get { return progress >= maxProgress; } }
    public Game(string name, string authorId, GameState state)
    { 
        this.name = name; 
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