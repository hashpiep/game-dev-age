using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    private List<Entity> entities = new List<Entity>();
    private string playerEntityId;
    private List<Game> games = new List<Game>();
    private void Awake()
    {
        entities.Add(new Human("player", new()));
        playerEntityId = "player";
    }
    public void CreateGame(string name)
    {
        games.Add(new Game(name, playerEntityId, GameState.InDevelopment));
    }
    public List<Game> GetGamesMadeByAuthorID(string authorId)
    {
        return games.Where(game => game.AuthorID == authorId).ToList();
    }
}