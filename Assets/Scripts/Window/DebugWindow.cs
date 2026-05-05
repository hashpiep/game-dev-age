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

        humMan.CreateHuman("Wilson", true);
        humMan.CreateHuman("Bill");
        humMan.CreateHuman("David");
        humMan.CreateHuman("Jane");
        humMan.CreateHuman("Carter");

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
        JMan.CreateJob("Janitor", 10);
        JMan.CreateJob("Cashier", 14);
        JMan.CreateJob("Car Washer", 14);

        moneyLabelScript.Init();
        timeLabelScript.Init();
    }
}