using System.Collections.Generic;
public class Human
{
    private string id;
    private Dictionary<string, Skill> skills;
    public string ID { get { return id; } }
    public Dictionary<string, Skill> Skills { get { return skills; } }
    public Human(string id, Dictionary<string, Skill> skills)
    {
        this.id = id;
        this.skills = skills;
    }
    public void IncreaseSkill(string skillKey, float howMuch)
    {
        Skill skill = skills[skillKey];

        if (skill == null)
            return;

        skill.AddProgress(howMuch);
    }
    public Skill GetSkill(string skillKey)
    {
        return skills[skillKey];
    }
}