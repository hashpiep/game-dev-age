using System.Collections.Generic;
public class Human : Entity
{
    private Dictionary<string, Skill> skills;
    public Dictionary<string, Skill> Skills { get { return skills; } }
    public Human(string id, Dictionary<string, Skill> skills) : base(id)
    {
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