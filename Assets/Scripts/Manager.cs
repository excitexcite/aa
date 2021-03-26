using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] Rotator rotator;
    [SerializeField] PinSpawner pinSpawner;
    private bool gameEnded = false;
 
    public void GameOver()
    {
        if (gameEnded)
        {
            return;
        }
        Debug.Log("ENDGAME");
        gameEnded = true;
        rotator.enabled = false;
        pinSpawner.enabled = false;
    }

}
