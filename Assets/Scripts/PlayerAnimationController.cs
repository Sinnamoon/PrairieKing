using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class PlayerAnimationController
{
    public Animator animator;
    public PlayerController playerMovementController;


    private const string _AnimParamHorizontalName = "Horizontal";
    private const string _AnimParamVerticalName = "Vertical";
    public void Movement(float Vertical, float Horizontal)
    {
        animator.SetFloat(_AnimParamVerticalName, Vertical);
        animator.SetFloat(_AnimParamHorizontalName, Horizontal);

    }
}
