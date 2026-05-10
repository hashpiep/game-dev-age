using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class ProgrammingLanguageManager : MonoBehaviour
{
    private List<ProgrammingLanguage> programmingLanguages = new List<ProgrammingLanguage>();
    private static ProgrammingLanguageManager instance;
    public static ProgrammingLanguageManager Instance { get { return instance; } }
    private void Start()
    {
        instance = this;
    }
    public void CreateProgLanguage(string name, string authorID, List<string> supportedPlatformsIDs, bool isFinishedAndReleased = false)
    {
        ProgrammingLanguageProperties properties = new ProgrammingLanguageProperties(0, 0, 0, 0, 0, 0, supportedPlatformsIDs);
        ProgrammingLanguage progLanguage = new ProgrammingLanguage($"{Guid.NewGuid().ToString()}_proglang", authorID, name, properties, isFinishedAndReleased);

        programmingLanguages.Add(progLanguage);
    }
    public List<ProgrammingLanguage> GetProgLanguages()
    {
        return programmingLanguages;
    }
    public ProgrammingLanguage GetProgLanguageFromID(string id)
    {
        return programmingLanguages.Where(progLang => progLang.ID == id).FirstOrDefault();
    }
}