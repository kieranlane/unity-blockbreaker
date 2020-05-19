using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBlocks; // Serialized for debugging purposes (Should be auto populated)
    [SerializeField] int finalLevelIndex;

    // Cached Reference
    SceneLoader sceneloader;

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (finalLevelIndex == currentSceneIndex)
            {
                sceneloader.LoadWinScene();
            }
            else
            {
                sceneloader.LoadNextScene();
            }
        }
    }
}
