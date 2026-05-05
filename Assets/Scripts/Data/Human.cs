using System.Collections.Generic;
public class Human
{
    private string id;
    private Dictionary<string, Skill> skills;
    private string jobID = "";
    private float money = 0;
    public string ID { get { return id; } }
    public string JobID { get { return jobID; } }
    public float Money { get { return money; } }
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
    public void SetJob(string jobID)
    {
        this.jobID = jobID;
    }
    public void RemoveMoney(float howMuch)
    {
        money -= howMuch;
    }
    public void AddMoney(float howMuch)
    {
        money += howMuch;
    }
    public Skill GetSkill(string skillKey)
    {
        return skills[skillKey];
    }
}