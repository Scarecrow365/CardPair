using System;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private MainMenuWindow mainMenuWindow;
    [SerializeField] private GamePlayWindow gamePlayWindow;

    private ISubWindow[] _subWindows;

    public event Action OnStartGame;
    public event Action OnRetryGame;
    public event Action OnQuitGame;

    private void Awake()
    {
        _subWindows = new ISubWindow[] { mainMenuWindow, gamePlayWindow };
    }

    private void OnEnable()
    {
        mainMenuWindow.OnStartButton += SubscribeStartButton;
        mainMenuWindow.OnRetryButton += SubscribeRetryButton;
        mainMenuWindow.OnQuitButton += SubscribeQuitButton;
    }

    private void OnDisable()
    {
        mainMenuWindow.OnStartButton -= SubscribeStartButton;
        mainMenuWindow.OnRetryButton -= SubscribeRetryButton;
        mainMenuWindow.OnQuitButton -= SubscribeQuitButton;
    }

    private void SetStartWindow()
    {
        foreach (var window in _subWindows)
        {
            window.ChangeState(subWindowName.Main);
        }
    }

    private void SetGamePlayWindow()
    {
        foreach (var window in _subWindows)
        {
            window.ChangeState(subWindowName.Gameplay);
        }
    }

    private void SubscribeStartButton() => OnStartGame?.Invoke();
    private void SubscribeRetryButton() => OnRetryGame?.Invoke();
    private void SubscribeQuitButton() => OnQuitGame?.Invoke();

    public void UpdateScore(int score) => gamePlayWindow.SetScore(score);
    public void UpdateLevel(int level) => gamePlayWindow.SetLevel(level);

    public void SetMain() => SetStartWindow();
    public void StartGame() => SetGamePlayWindow();
}