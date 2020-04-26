using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] int startSceneIndex = 0;
    [SerializeField] int winSceneIndex = 1;
    [SerializeField] int gameoverSceneIndex = 2;
    [SerializeField] int levelSceneIndex = 3;

    GameSession gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(startSceneIndex);
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene(winSceneIndex);
        gameStatus.ResetGame();
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(gameoverSceneIndex);
        gameStatus.ResetGame();
    }

    public void LoadLevelScene(int levelIncrement)
    {
        SceneManager.LoadScene(levelSceneIndex + levelIncrement);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}