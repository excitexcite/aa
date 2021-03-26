using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimator : MonoBehaviour
{

    [SerializeField] Animator animator; // reference to animator component that is placed on main camera

    public void SetGameOverTrigger()
    {
        animator.SetTrigger("GameOver");
    }

    public void SetLevelCompleteTrigger()
    {
        animator.SetTrigger("LevelComplete");
    }
}

