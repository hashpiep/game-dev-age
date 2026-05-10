using System.Collections.Generic;
using UnityEngine;
public class DebugWindow : MonoBehaviour
{
    [SerializeField]
    private MoneyLabel moneyLabelScript;
    [SerializeField]
    private TimeLabel timeLabelScript;
    public void InitializeEverything()
    {
        HumanManager humMan = HumanManager.Instance;

        humMan.CreateHuman(RNDNameManager.GetRandomMaleFirstName(), RNDNameManager.GetRandomLastName(), Sex.Male, true);
        humMan.CreateHuman(RNDNameManager.GetRandomMaleFirstName(), RNDNameManager.GetRandomLastName(), Sex.Male);
        humMan.CreateHuman(RNDNameManager.GetRandomMaleFirstName(), RNDNameManager.GetRandomLastName(), Sex.Male);
        humMan.CreateHuman(RNDNameManager.GetRandomMaleFirstName(), RNDNameManager.GetRandomLastName(), Sex.Male);
        humMan.CreateHuman(RNDNameManager.GetRandomFemaleFirstName(), RNDNameManager.GetRandomLastName(), Sex.Female);
        humMan.CreateHuman(RNDNameManager.GetRandomFemaleFirstName(), RNDNameManager.GetRandomLastName(), Sex.Female);

        GamingPlatformManager GPMan = GamingPlatformManager.Instance;
        ProgrammingLanguageManager PLMan = ProgrammingLanguageManager.Instance;

        GPMan.CreateGamingPlatform("BIDA");
        GPMan.CreateGamingPlatform("Semipole");
        GPMan.CreateGamingPlatform("Omnipole");
        GPMan.CreateGamingPlatform("Eyes");

        List<GamingPlatform> platforms = GPMan.GetGamingPlatforms();

        List<string> firstLang = new List<string>();
        firstLang.Add(platforms[0].ID);
        firstLang.Add(platforms[1].ID);

        List<string> secondLang = new List<string>();
        secondLang.Add(platforms[3].ID);

        List<string> thirdLang = new List<string>();
        thirdLang.Add(platforms[0].ID);
        thirdLang.Add(platforms[1].ID);
        thirdLang.Add(platforms[2].ID);

        List<string> fourthLang = new List<string>();
        fourthLang.Add(platforms[2].ID);

        List<Human> humans = humMan.GetHumans();

        string authorIdOne = humans[1].ID;
        string authorIdTwo = humans[2].ID;
        string authorIdThree = humans[4].ID;

        PLMan.CreateProgLanguage(RNDNameManager.GenerateProgrammingLanguageName(HumanManager.Instance.GetHumanFromID(authorIdOne).Info), 
            authorIdOne, firstLang, true);
        PLMan.CreateProgLanguage(RNDNameManager.GenerateProgrammingLanguageName(HumanManager.Instance.GetHumanFromID(authorIdThree).Info), 
            authorIdThree, secondLang, true);
        PLMan.CreateProgLanguage(RNDNameManager.GenerateProgrammingLanguageName(HumanManager.Instance.GetHumanFromID(authorIdTwo).Info), 
            authorIdTwo, thirdLang, true);
        PLMan.CreateProgLanguage(RNDNameManager.GenerateProgrammingLanguageName(HumanManager.Instance.GetHumanFromID(authorIdTwo).Info), 
            authorIdTwo, fourthLang, true);

        JobManager JMan = JobManager.Instance;
        JMan.CreateJob("Janitor", 10, new Shift(new List<int> {1, 2, 3, 4, 5}, 12, 30, 15, 30));
        JMan.CreateJob("Cashier", 14, new Shift(new List<int> { 1, 3, 5, 6 }, 7, 0, 15, 0));
        JMan.CreateJob("Car Washer", 14, new Shift(new List<int> { 1, 2, 3, 4, 5, 6, 7 }, 9, 0, 17, 0));

        moneyLabelScript.Init();
        timeLabelScript.Init();
    }
}