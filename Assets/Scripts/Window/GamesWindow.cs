using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamesWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject gamesWindow;
    [SerializeField]
    private Transform container;
    [SerializeField]
    private GamePrefab gamePrefab;
    [SerializeField]
    private CreateGamePrefab createGamePrefab;
    [Header("Other Window Scripts")]
    [SerializeField]
    private CreateGameWindow createGameWindow;
    [Header("Statistics & Development")]
    [SerializeField]
    private TMP_Text statisticsLabel;
    [SerializeField]
    private Button workBtn;
    [SerializeField]
    private Button releaseGameBtn;
    private void Start()
    {
        Close();
        workBtn.gameObject.SetActive(false);
        statisticsLabel.gameObject.SetActive(false);
        releaseGameBtn.gameObject.SetActive(false);
    }
    public void Close()
    {
        gamesWindow.SetActive(false);
    }
    public void Show()
    {
        gamesWindow.SetActive(true);

        GeneratePlayerGames();
    }
    private void GenerateGames(List<Game> games, bool isCreateGamePrefabAtBeggining)
    {
        Extensions.KillAllChildrenOfParent(container);

        if (isCreateGamePrefabAtBeggining)
        {
            var cgPrefab = Instantiate(createGamePrefab, container);
            cgPrefab.UpdateUI(OnCreateGameBtnClicked);
        }

        foreach (var game in games)
        {
            var gPrefab = Instantiate(gamePrefab, container);
            gPrefab.UpdateUI($"{game.Name} - {((game.State == ProductState.Released) ? "RELEASED" : "IN DEVELOPMENT")}", () => OnGameBtnClicked(game));
        }
    }
    public void GeneratePlayerGames()
    {
        List<Game> gamesMadeByPlayer = GameManager.Instance.GetGamesMadeByAuthorID(HumanManager.Instance.PlayerID);

        GenerateGames(gamesMadeByPlayer, true);
    }
    public void GenerateOtherGames()
    {
        List<Game> gamesMadeByOthers = GameManager.Instance.GetGamesNotMadeByAuthorID(HumanManager.Instance.PlayerID);

        GenerateGames(gamesMadeByOthers, false);
    }
    private void OnCreateGameBtnClicked()
    {
        createGameWindow.Show();
        Close();
    }
    private void OnGameBtnClicked(Game game)
    {
        if (game.AuthorID != HumanManager.Instance.PlayerID)
            return;

        if (game.State == ProductState.Released || game.IsFinished)
            ShowStatistics(game);
        else if (game.State == ProductState.InDevelopment)
            ShowDevelopment(game);
    }
    private void ShowStatistics(Game game)
    {
        workBtn.gameObject.SetActive(false);
        statisticsLabel.gameObject.SetActive(true);

        if (game.State != ProductState.Released)
            releaseGameBtn.gameObject.SetActive(true);
        else
            releaseGameBtn.gameObject.SetActive(false);

        Human author = HumanManager.Instance.GetHumanFromID(game.AuthorID);

        statisticsLabel.text = $"{game.Name} made by {author.Info.FirstName} {author.Info.LastName}";

        releaseGameBtn.onClick.RemoveAllListeners();
        releaseGameBtn.onClick.AddListener(() =>
        {
            game.Release();
            GeneratePlayerGames();
            ShowStatistics(game);
        });
    }
    private void ShowDevelopment(Game game)
    {
        workBtn.gameObject.SetActive(true);
        statisticsLabel.gameObject.SetActive(true);
        releaseGameBtn.gameObject.SetActive(false);

        Human author = HumanManager.Instance.GetHumanFromID(game.AuthorID);
        statisticsLabel.text = $"{game.Name} made by {author.Info.FirstName} {author.Info.LastName}";

        workBtn.onClick.RemoveAllListeners();
        workBtn.onClick.AddListener(() =>
        {
            game.AddProgress(5);
            TimeManager.Instance.PassTimeInHoursAndMinutes(30, 2);

            if (game.IsFinished)
            {
                ShowStatistics(game);
                GeneratePlayerGames();
            }
        });
    }
}
