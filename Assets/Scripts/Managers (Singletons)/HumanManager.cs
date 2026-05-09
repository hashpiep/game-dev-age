using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class HumanManager : MonoBehaviour
{
    private List<Human> humans = new List<Human>();
    private string playerID;
    private static HumanManager instance;
    public static HumanManager Instance { get { return instance; } }
    public string PlayerID { get { return playerID; } }
    private void Start()
    {
        instance = this;
    }
    public void CreateHuman(string firstName, string lastName, Sex sex, bool isPlayer = false)
    {
        Human human = new Human($"{Guid.NewGuid().ToString()}_human", new HumanInfo(firstName, lastName, sex), new());

        if (isPlayer)
            playerID = human.ID;

        humans.Add(human);
    }
    public List<Human> GetHumans()
    {
        return humans;
    }
    public Human GetHumanFromID(string id)
    {
        return humans.Where(human => human.ID == id).FirstOrDefault();
    }
}