public class ProgrammingLanguage
{
    private string id;
    private string authorId;
    private string name;
    private float progress = 0;
    private float maxProgress = 100;
    private ProgrammingLanguageProperties properties;
    private ProductState state;
    public ProductState State { get { return state; } }
    public string ID { get { return id; } }
    public string AuthorID { get { return authorId; } }
    public string Name { get { return name; } }
    public ProgrammingLanguageProperties Properties { get { return properties; } }
    public bool IsFinished { get { return progress >= maxProgress; } }
    public ProgrammingLanguage(string id, string authorId, string name, ProgrammingLanguageProperties properties, bool isFinishedAndReleased = false)
    {
        this.id = id;
        this.authorId = authorId;
        this.name = name;
        this.properties = properties;

        if (isFinishedAndReleased)
        {
            progress = maxProgress;
            state = ProductState.Released;
        } else
        {
            progress = 0;
            state = ProductState.InDevelopment;
        }
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