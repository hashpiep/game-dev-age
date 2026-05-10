using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    private List<Game> games = new List<Game>();
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private void Start()
    {
        instance = this;
    }
    public void CreateGame(string name, string programmingLanguageID, string authorID, string gamingPlatformID)
    {
        games.Add(new Game($"{Guid.NewGuid().ToString()}_game", name, authorID, programmingLanguageID, gamingPlatformID, ProductState.InDevelopment));
    }
    public List<Game> GetGamesMadeByAuthorID(string authorId)
    {
        return games.Where(game => game.AuthorID == authorId).ToList();
    }
    public List<Game> GetGamesNotMadeByAuthorID(string authorId)
    {
        return games.Where(game => game.AuthorID != authorId).ToList();
    }
    public List<Game> GetGames()
    {
        return games;
    }
}