using System.Collections.Generic;
public class ProgrammingLanguageProperties
{
    private int performance;
    private int memoryManagement;
    private int debugging;
    private int syntax;
    private int ecosystem;
    private int complexity;
    private List<string> supportedGamingPlatformsIDs;
    public int Performance { get { return performance; } }
    public int MemoryManagement { get { return memoryManagement; } }
    public int Debugging { get { return debugging; } }
    public int Syntax { get { return syntax; } }
    public int Ecosystem { get { return ecosystem; } }
    public int Complexity { get { return complexity; } }
    public List<string> SupportedGamingPlatformsIDs { get { return supportedGamingPlatformsIDs; } }
    public ProgrammingLanguageProperties(int performance, int memoryManagement, int debugging, int syntax, int ecosystem, int complexity, List<string> supportedGamingPlatformsIDs)
    {
        this.performance = performance;
        this.memoryManagement = memoryManagement;
        this.debugging = debugging;
        this.syntax = syntax;
        this.ecosystem = ecosystem;
        this.complexity = complexity;
        this.supportedGamingPlatformsIDs = supportedGamingPlatformsIDs;
    }
}
