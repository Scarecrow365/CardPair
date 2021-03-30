using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : MonoBehaviour, ISubWindow
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    private TextMeshProUGUI _startText;

    public event Action OnStartButton;
    public event Action OnRetryButton;
    public event Action OnQuitButton;

    private bool _isGameStarted;
    private const subWindowName SubWindowName = subWindowName.Main;

    private void Awake()
    {
        _startText = GetComponentInChildren<TextMeshProUGUI>();
        startButton.onClick.AddListener(StartButtonPressed);
        quitButton.onClick.AddListener(() => OnQuitButton?.Invoke());
    }

    private void StartButtonPressed()
    {
        if (_isGameStarted)
        {
            OnRetryButton?.Invoke();
        }
        else
        {
            OnStartButton?.Invoke();
            _isGameStarted = true;
        }
    }

    private void OnEnable()
    {
        _startText.text = _isGameStarted ? "Retry" : "Start Game";
    }

    public void ChangeState(subWindowName windowName)
    {
        gameObject.SetActive(SubWindowName == windowName);
    }
}
