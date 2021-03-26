using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] Rotator rotator; // reference to rotator object
    [SerializeField] PinSpawner pinSpawner; // reference to pinSpawner object
    private bool gameEnded = false; // variable that prevent calling GameOver() method more than one time
 
    public void GameOver()
    {
        // if the game has ended no action will be done
        if (gameEnded)
        {
            return;
        }
        Debug.Log("ENDGAME");
        gameEnded = true; 
        rotator.enabled = false; // disable the rotator component
        pinSpawner.enabled = false; // disable the pinSpawner component
    }

}
