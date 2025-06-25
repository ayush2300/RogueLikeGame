using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState { MainMenu, Gameplay, Paused, GameOver }
    public GameState CurrentState { get; private set; }

    public static event System.Action<GameState> GameStateChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        ChangeState(GameState.MainMenu);
    }

    private void Update()
    {
        if (CurrentState == GameState.Gameplay && Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        else if (CurrentState == GameState.Paused && Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        GameStateChanged?.Invoke(newState);

        if (newState == GameState.MainMenu)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (newState == GameState.Gameplay && SceneManager.GetActiveScene().name != "DEV C")
        {
            SceneManager.LoadScene("DEV C");
        }
    }

    public void TogglePause()
    {
        if (CurrentState == GameState.Gameplay)
        {
            Time.timeScale = 0f;
            CurrentState = GameState.Paused;
            GameStateChanged?.Invoke(CurrentState);
        }
        else if (CurrentState == GameState.Paused)
        {
            Time.timeScale = 1f;
            CurrentState = GameState.Gameplay;
            GameStateChanged?.Invoke(CurrentState);
        }
    }
}
