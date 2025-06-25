using UnityEngine;

public enum GameState
{
    MainMenu,
    Gameplay,
    Paused,
    BossFight,
    GameOver
}

public class GameStateHandler : MonoBehaviour
{
    public static GameStateHandler Instance { get; private set; }
    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;
        Time.timeScale = (newState == GameState.Paused) ? 0 : 1;
    }

    public bool IsPlaying() => CurrentState == GameState.Gameplay;
    public bool IsPaused() => CurrentState == GameState.Paused;
}
