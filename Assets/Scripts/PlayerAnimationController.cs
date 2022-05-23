using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class PlayerAnimationController
{
    public Animator animator;
    public PlayerMovementController playerMovementController;
    public void Movement(int Vertical, int Horizontal)
    {
        animator.SetInteger("Vertical", Vertical);
        animator.SetInteger("Horizontal", Horizontal);

    }
}
