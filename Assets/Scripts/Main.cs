using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private RulesHolder rulesHolder;

    private UIController _uiController;
    private LevelCreator _levelCreator;
    private LevelController _levelController;

    private void Awake()
    {
        _uiController = GetComponent<UIController>();
        _levelCreator = gameObject.AddComponent<LevelCreator>();
        _levelController = gameObject.AddComponent<LevelController>();
    }

    private void OnEnable()
    {
        _uiController.OnStartGame += StartGame;
        _uiController.OnRetryGame += RetryGame;
        _uiController.OnQuitGame += QuitGame;
    }
    private void OnDisable()
    {
        _uiController.OnStartGame -= StartGame;
        _uiController.OnRetryGame -= RetryGame;
        _uiController.OnQuitGame -= QuitGame;
    }

    private void Start()
    {
        PrepareGame();
    }

    private void PrepareGame()
    {
        _uiController.SetMain();
    }

    private void StartGame()
    {
        _uiController.StartGame();
        _levelCreator.StartGame(rulesHolder);
        _levelController.StartGame(_levelCreator.GetCards());
    }

    private void QuitGame()
    {
        Debug.Log("Quit Game");
    }

    private void RetryGame()
    {
        Debug.Log("Restart Game");
    }
}
