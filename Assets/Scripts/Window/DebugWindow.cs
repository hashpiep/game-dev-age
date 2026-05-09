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
        humMan.CreateHuman(RNDNameManager.GetRandomFemaleFirstName(), RNDNameManager.GetRandomLastName(), Sex.Female);
        humMan.CreateHuman(RNDNameManager.GetRandomFemaleFirstName(), RNDNameManager.GetRandomLastName(), Sex.Female);

        GamingPlatformManager GPMan = GamingPlatformManager.Instance;
        ProgrammingLanguageManager PLMan = ProgrammingLanguageManager.Instance;

        GPMan.CreateGamingPlatform("BIDA");
        GPMan.CreateGamingPlatform("Semipole");
        GPMan.CreateGamingPlatform("Omnipole");
        GPMan.CreateGamingPlatform("Kakari");

        List<GamingPlatform> platforms = GPMan.GetGamingPlatforms();

        List<string> billy = new List<string>();
        billy.Add(platforms[0].ID);
        billy.Add(platforms[1].ID);

        List<string> eyes = new List<string>();
        eyes.Add(platforms[3].ID);

        List<string> classic = new List<string>();
        classic.Add(platforms[0].ID);
        classic.Add(platforms[1].ID);
        classic.Add(platforms[2].ID);

        List<string> ezscript = new List<string>();
        ezscript.Add(platforms[2].ID);

        PLMan.CreateProgLanguage("Billy", billy);
        PLMan.CreateProgLanguage("Eyes", eyes);
        PLMan.CreateProgLanguage("CLASSIC 1.0", classic);
        PLMan.CreateProgLanguage("EzScript 1.0", ezscript);

        JobManager JMan = JobManager.Instance;
        JMan.CreateJob("Janitor", 10, new Shift(new List<int> {1, 2, 3, 4, 5}, 12, 30, 15, 30));
        JMan.CreateJob("Cashier", 14, new Shift(new List<int> { 1, 3, 5, 6 }, 7, 0, 15, 0));
        JMan.CreateJob("Car Washer", 14, new Shift(new List<int> { 1, 2, 3, 4, 5, 6, 7 }, 9, 0, 17, 0));

        moneyLabelScript.Init();
        timeLabelScript.Init();
    }
}