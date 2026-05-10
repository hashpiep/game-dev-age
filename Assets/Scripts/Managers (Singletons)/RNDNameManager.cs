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
    private static string chemicalElementsPath = "Assets/Names/chemical_elements.json";
    private static string progLangWordsPath = "Assets/Names/proglang_words.json";
    private static string[] letters = new string[] 
    { 
        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
    };
    private static string[] symbols = new string[]
    {
        "*", "++", "#", "!", "+"
    };
    public static string GetRandomMaleFirstName()
    {
        List<string> maleNames = GetList(firstMaleNamesPath);
        List<string> unisexNames = GetList(firstUnisexNamesPath);
        List<string> names = new List<string>();
        names.AddRange(maleNames);
        names.AddRange(unisexNames);

        int rnd = Random.Range(0, names.Count);

        return names[rnd];
    }
    public static string GetRandomFemaleFirstName()
    {
        List<string> femaleNames = GetList(firstFemaleNamesPath);
        List<string> unisexNames = GetList(firstUnisexNamesPath);
        List<string> names = new List<string>();
        names.AddRange(femaleNames);
        names.AddRange(unisexNames);

        int rnd = Random.Range(0, names.Count);

        return names[rnd];
    }
    public static string GenerateProgrammingLanguageName(HumanInfo authorInfo)
    {
        string name = "";
        int rnd = Random.Range(0, 4);

        if (rnd == 0)
        {
            string finalName = GetRandomChemicalElement();

            if (finalName.Length < 8)
            {
                int rnd2 = Random.Range(0, 2);

                if (rnd2 == 0)
                    finalName += GetRandomProgLangWord();
            }

            name = finalName;
        }
        else if (rnd == 1)
        {
            int rnd2 = Random.Range(0, 2);
            string finalName = "";

            if (rnd2 == 0)
                finalName += authorInfo.FirstName[0].ToString().ToUpper();
            else
                finalName += authorInfo.LastName[0].ToString().ToUpper();

            int rnd3 = Random.Range(0, 2);

            if (rnd3 == 0)
                finalName += GetRandomSymbol();

            name = finalName;
        }
        else if (rnd == 2)
        {
            int rnd2 = Random.Range(0, 2);
            string finalName = "";

            if (rnd2 == 0)
                finalName = authorInfo.FirstName;
            else
                finalName = authorInfo.LastName;

            int rnd3 = Random.Range(0, 3);

            if (rnd3 == 0)
                finalName = finalName.ToUpper();
            else if (rnd3 == 1)
                finalName += GetRandomProgLangWord();

            name = finalName;
        }
        else
        {
            string finalName = GetRandomLetter(true);
            int rnd2 = Random.Range(0, 2);

            if (rnd2 == 0)
                finalName += GetRandomSymbol();

            name = finalName;
        }

        return name;
    }
    public static string GetRandomLastName()
    {
        var names = GetList(lastNamesPath);
        int rnd = Random.Range(0, names.Count);

        return names[rnd];
    }
    public static string GetRandomChemicalElement()
    {
        var elements = GetList(chemicalElementsPath);
        int rnd = Random.Range(0, elements.Count);

        return elements[rnd];
    }
    public static string GetRandomLetter(bool uppercase = true)
    {
        int rnd = Random.Range(0, letters.Length);

        if (uppercase)
            return letters[rnd].ToUpper();

        return letters[rnd].ToLower();
    }
    public static string GetRandomProgLangWord()
    {
        var words = GetList(progLangWordsPath);
        int rnd = Random.Range(0, words.Count);

        return words[rnd];
    }
    public static string GetRandomSymbol()
    {
        int rnd = Random.Range(0, symbols.Length);

        return symbols[rnd];
    }
    private static List<string> GetList(string path)
    {
        string json = File.ReadAllText(path);
        List<string> list = JsonConvert.DeserializeObject<List<string>>(json);

        return list;
    }
}