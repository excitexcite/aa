using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject textMeshProObject; // reference to textMeshPro object to show next loaded level
    [SerializeField] Level level; // reference to Level object

    // Start is called before the first frame update
    void Start()
    {
        int passedLevelIndex = PlayerPrefs.GetInt(Level.LEVEL_KEY, 1); // getting last passed level index
        int lastLevelIndex = level.GetTotalSceneNumber() - 1; // getting the very last scene index
        // if the next loaded scene is not the last scene
        if (passedLevelIndex < lastLevelIndex)
        {
            // show textMeshPro object
            textMeshProObject.SetActive(true);
            // setting up the text
            textMeshProObject.GetComponent<TextMeshProUGUI>().text = "Play level " + (passedLevelIndex + 1).ToString();
        }
        else // not showing textMeshPro object or show "End" text
        {
            textMeshProObject.SetActive(false);
            textMeshProObject.GetComponent<TextMeshProUGUI>().text = "The End";
        }
    }
}
