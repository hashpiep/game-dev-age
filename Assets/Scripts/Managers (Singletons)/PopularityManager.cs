using System.Collections.Generic;
using UnityEngine;
public class PopularityManager : MonoBehaviour
{
    private Dictionary<string, int> gamingPlatformPopularities = new Dictionary<string, int>();
    private static PopularityManager instance;
    public static PopularityManager Instance { get { return instance; } }
    private void Start()
    {
        instance = this;
    }
    public void AddPopularityPoints(string gamePlatformID, int pointsAmount)
    {
        if (!gamingPlatformPopularities.ContainsKey(gamePlatformID))
            gamingPlatformPopularities.Add(gamePlatformID, pointsAmount);
        else
            gamingPlatformPopularities[gamePlatformID] += pointsAmount;
    }
    public void RemovePopularityPoints(string gamePlatformID, int pointsAmount)
    {
        if (!gamingPlatformPopularities.ContainsKey(gamePlatformID))
            gamingPlatformPopularities.Add(gamePlatformID, pointsAmount);
        else
            gamingPlatformPopularities[gamePlatformID] -= pointsAmount;
    }
    public float GetPercentageofPopularityByID(string gamePlatformID)
    {
        int allPoints = 0;

        foreach (var key in gamingPlatformPopularities.Keys)
        {
            allPoints += gamingPlatformPopularities[key];
        }

        if (!gamingPlatformPopularities.ContainsKey(gamePlatformID))
            gamingPlatformPopularities.Add(gamePlatformID, 0);

        int currentPoints = gamingPlatformPopularities[gamePlatformID];

        float result = (float)currentPoints / (float)allPoints * 100f;

        return result;
    }
}