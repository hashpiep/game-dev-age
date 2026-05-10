public class Skill
{
    private string displayName;
    private string categoryName;
    private float progress;
    private float maxProgress;
    private int level;
    private int maxLevel;
    public string DisplayName { get { return displayName; } }
    public string CategoryName { get { return categoryName; } }
    public float Progress { get { return progress; } }
    public float MaxProgress { get { return maxProgress; } }
    public int Level { get { return level; } }
    public int MaxLevel { get { return maxLevel; } }
    public bool MaxxedOut { get { return level >= maxLevel; } }
    public Skill(string displayName, string categoryName, float maxProgress, int maxLevel)
    {
        this.displayName = displayName;
        this.categoryName = categoryName;
        this.maxProgress = maxProgress;
        this.maxLevel = maxLevel;

        progress = 0;
        level = 0;
    }
    public void AddProgress(float howMuch)
    {
        progress += howMuch;

        while (progress >= maxProgress)
        {
            progress -= maxProgress;
            level++;
            maxProgress *= 1.5f;

            if (level >= maxLevel)
                return;
        }
    }
}