public class Book
{
    private string id;
    private string name;
    private float price;
    private string authorID;
    private string skillKey;
    public string ID { get { return id; } }
    public string Name { get { return name; } }
    public float Price { get { return price; } }
    public string AuthorID { get { return authorID; } }
    public string SkillKey { get { return skillKey; } }
    public Book(string id, string name, float price, string authorID, string skillKey)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.authorID = authorID;
        this.skillKey = skillKey;
    }
}