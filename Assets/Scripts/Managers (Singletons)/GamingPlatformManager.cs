using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
public class GamingPlatformManager : MonoBehaviour
{
    private List<GamingPlatform> gamingPlatforms = new List<GamingPlatform>();
    private static GamingPlatformManager instance;
    public static GamingPlatformManager Instance { get { return instance; } }
    private void Start()
    {
        instance = this;
    }
    public void CreateGamingPlatform(string name)
    {
        GamingPlatform gamingPlatform = new GamingPlatform($"{Guid.NewGuid().ToString()}_gameplat", name);

        gamingPlatforms.Add(gamingPlatform);
    }
    public List<GamingPlatform> GetGamingPlatforms()
    {
        return gamingPlatforms;
    }
    public GamingPlatform GetGamingPlatformFromID(string id)
    {
        return gamingPlatforms.Where(gamingPlatform => gamingPlatform.ID == id).FirstOrDefault();
    }
}