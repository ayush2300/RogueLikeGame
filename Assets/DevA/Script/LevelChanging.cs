using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanging : MonoBehaviour
{
    [Header("Scene names to loop through")]
    public List<string> sceneNames;

    [Header("Time before switching to next scene (in seconds)")]
    public float timeBeforeSwitch = 5f;

    private void Start()
    {
        // Start the loop after some delay
        StartCoroutine(LoadRandomSceneAfterDelay());
    }

    IEnumerator LoadRandomSceneAfterDelay()
    {
        yield return new WaitForSeconds(timeBeforeSwitch);

        // Pick a random scene (excluding the current one if needed)
        string currentScene = SceneManager.GetActiveScene().name;
        string nextScene;

        do
        {
            nextScene = sceneNames[Random.Range(0, sceneNames.Count)];
        } while (nextScene == currentScene && sceneNames.Count > 1);

        // Load the new scene (single mode to unload the current one)
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
