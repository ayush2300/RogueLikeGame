using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainMenuUI;
    public GameObject pauseMenuUI;

    private void OnEnable()
    {
        GameManager.GameStateChanged += OnGameStateChanged;
    }

    private void OnDisable()
    {
        GameManager.GameStateChanged -= OnGameStateChanged;
    }

    private void Start()
    {
        OnGameStateChanged(GameManager.Instance.CurrentState);
    }

    private void OnGameStateChanged(GameManager.GameState state)
    {
        if (mainMenuUI != null)
            mainMenuUI.SetActive(state == GameManager.GameState.MainMenu);

        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(state == GameManager.GameState.Paused);
    }

    public void StartGame()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.Gameplay);
    }

    public void ResumeGame()
    {
        GameManager.Instance.TogglePause();
    }

    public void ReturnToMainMenu()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.MainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
