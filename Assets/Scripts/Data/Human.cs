using System;
using System.Collections.Generic;
public class Human
{
    private string id;
    private HumanInfo info;
    private Dictionary<string, Skill> skills;
    private List<string> boughtBooksIDs;
    private string jobID = "";
    private float money = 0;
    public string ID { get { return id; } }
    public HumanInfo Info { get { return info; } }
    public List<string> BoughtBooksIDs { get { return boughtBooksIDs; } }
    public string JobID { get { return jobID; } }
    public float Money { get { return money; } }
    public Dictionary<string, Skill> Skills { get { return skills; } }
    public event Action<float> OnMoneyChanged;
    public Human(string id, HumanInfo info, Dictionary<string, Skill> skills, List<string> boughtBooksIDs)
    {
        this.id = id;
        this.info = info;
        this.skills = skills;
        this.boughtBooksIDs = boughtBooksIDs;
    }
    /// <param name="newSkill">This parameter adds the skill to the human's skill dictionary if it doesn't exist.</param>
    public void IncreaseSkill(string skillKey, float howMuch, Skill newSkill = null)
    {
        if (!skills.ContainsKey(skillKey))
            if (newSkill != null)
                CreateSkill(skillKey, newSkill);
            else
                return;

        Skill skill = skills[skillKey];

        skill.AddProgress(howMuch);
    }
    public void CreateSkill(string newSkillKey, Skill skill)
    {
        if (skills.ContainsKey(newSkillKey))
            return;

        skills.Add(newSkillKey, skill);
    }
    public void SetJob(string jobID)
    {
        this.jobID = jobID;
    }
    public void RemoveMoney(float howMuch)
    {
        money -= howMuch;
        OnMoneyChanged?.Invoke(money);
    }
    public void AddMoney(float howMuch)
    {
        money += howMuch;
        OnMoneyChanged?.Invoke(money);
    }
    public Skill GetSkill(string skillKey)
    {
        return skills[skillKey];
    }
}