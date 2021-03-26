using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
        int passedLevelIndex = PlayerPrefs.GetInt(LEVEL_KEY, LEVEL_TO_START);
        SceneManager.LoadScene(passedLevelIndex);
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = PlayerPrefs.GetInt(LEVEL_KEY, LEVEL_TO_START) + 1;
        if (nextSceneIndex != totalSceneNumber)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void ReloadScene()
    {
        int passedLevelIndex = PlayerPrefs.GetInt(LEVEL_KEY, LEVEL_TO_START);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    public void LoadScene(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
