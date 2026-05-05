using System.Collections.Generic;
public class ProgrammingLanguage
{
    private string id;
    private string name;
    private List<string> supportedGamingPlatformsIDs;
    public string ID { get { return id; } }
    public string Name { get { return name; } }
    public List<string> SupportedGamingPlatformsIDs { get { return supportedGamingPlatformsIDs; } }
    public ProgrammingLanguage(string id, string name, List<string> supportedGamingPlatformsIDs)
    {
        this.id = id;
        this.name = name;
        this.supportedGamingPlatformsIDs = supportedGamingPlatformsIDs;
    }
}