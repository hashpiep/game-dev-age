using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class RNDNameManager
{
    private static string firstMaleNamesPath = "Assets/Names/first_names_male.json";
    private static string firstFemaleNamesPath = "Assets/Names/first_names_female.json";
    private static string firstUnisexNamesPath = "Assets/Names/first_names_unisex.json";
    private static string lastNamesPath = "Assets/Names/last_names.json";
    public static string GetRandomMaleFirstName()
    {
        string jsonMale = File.ReadAllText(firstMaleNamesPath);
        List<string> maleNames = JsonConvert.DeserializeObject<List<string>>(jsonMale);

        string jsonUnisex = File.ReadAllText(firstUnisexNamesPath);
        List<string> unisexNames = JsonConvert.DeserializeObject<List<string>>(jsonUnisex);

        List<string> names = new List<string>();
        names.AddRange(maleNames);
        names.AddRange(unisexNames);

        int rnd = Random.Range(0, names.Count);

        return names[rnd];
    }
    public static string GetRandomFemaleFirstName()
    {
        string jsonFemale = File.ReadAllText(firstFemaleNamesPath);
        List<string> femaleNames = JsonConvert.DeserializeObject<List<string>>(jsonFemale);

        string jsonUnisex = File.ReadAllText(firstUnisexNamesPath);
        List<string> unisexNames = JsonConvert.DeserializeObject<List<string>>(jsonUnisex);

        List<string> names = new List<string>();
        names.AddRange(femaleNames);
        names.AddRange(unisexNames);

        int rnd = Random.Range(0, names.Count);

        return names[rnd];
    }
    public static string GetRandomLastName()
    {
        string json = File.ReadAllText(lastNamesPath);
        List<string> names = JsonConvert.DeserializeObject<List<string>>(json);
        int rnd = Random.Range(0, names.Count);

        return names[rnd];
    }
}