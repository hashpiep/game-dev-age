using System.Collections.Generic;
using UnityEngine;
public class ReleaseGameWindow : MonoBehaviour
{
    [SerializeField]
    private Transform container;
    [SerializeField]
    private ReleaseGamePrefab releaseGamePrefab;
    [SerializeField]
    private GameObject releaseGameWindow;
    private void Start()
    {
        Close();
    }
    public void Close()
    {
        releaseGameWindow.SetActive(false);
    }
    public void Show()
    {
        releaseGameWindow.SetActive(true);
        GenerateUnreleasedGames();
    }
    private void GenerateUnreleasedGames()
    {
        Extensions.KillAllChildrenOfParent(container);

        List<Game> games = GameManager.Instance.GetGamesMadeByAuthorID(HumanManager.Instance.PlayerID);

        foreach (Game game in games)
        {
            if (!game.IsFinished || game.State == GameState.Released)
                continue;

            var obj = Instantiate(releaseGamePrefab, container);
            obj.Init(game.Name, () =>
            {
                game.Release();
                GenerateUnreleasedGames();
            });
        }
    }
}