using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// In this script scenes that are not game levels load by thier names (titles), and scenes which are levels
/// load by the scene index. Such approarch requires to place game levels from 0 to N in unity build settings, and place
/// non-level scene after all the levels
/// </summary>
/// 

public class Level : MonoBehaviour
{

    // static variables for constant Level values
    public static string LEVEL_KEY = "levelReached"; 
    public static int LEVEL_TO_START = 0;
    [SerializeField] Button[] levelButtons;
    [SerializeField] int totalSceneNumber = 30;

    // Start is called before the first frame update
    void Start()
    {
        // if level load buttons array was not assign in editor abort running this fuction
        if (levelButtons.Length == 0)
        {
            return;
        }
        // getting the number of last complete level
        int levelReached = PlayerPrefs.GetInt(LEVEL_KEY, LEVEL_TO_START);
        // making buttons for unreached levels unactive
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public int GetTotalSceneNumber() { return totalSceneNumber; }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLastPassedScene()
    {
        // getting the last passed scene index
        int passedLevelIndex = PlayerPrefs.GetInt(LEVEL_KEY, LEVEL_TO_START);
        SceneManager.LoadScene(passedLevelIndex);
    }

    public void LoadNextScene()
    {
        // getting the last passed scene index and increase it by one to load next scene
        int nextSceneIndex = PlayerPrefs.GetInt(LEVEL_KEY, LEVEL_TO_START) + 1;
        if (nextSceneIndex != totalSceneNumber)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void ReloadScene()
    {
        // getting the last passed scene index
        int passedLevelIndex = PlayerPrefs.GetInt(LEVEL_KEY, LEVEL_TO_START);
        SceneManager.LoadScene(passedLevelIndex + 1);
    }

    public void LoadLevelSelectorScene()
    {
        SceneManager.LoadScene("LevelSelectionScene");
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("LevelFailedScene");
    }

    public void LoadLevelCompleteScene()
    {
        SceneManager.LoadScene("LevelCompleteScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    // loading the scene by point the level to load
    public void LoadScene(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
