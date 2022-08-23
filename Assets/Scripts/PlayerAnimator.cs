using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void AnimType(string animType)
    {
        switch (animType)
        {
            case "StartIdle":
                animator.SetBool("StairRun", false);
                animator.SetBool("StairRest", false);
                animator.SetBool("StairRest2", false);
                break;
            case "StairRun":
                animator.SetBool("StairRun", true);
                animator.SetBool("StairRest", false);
                animator.SetBool("StairRest2", false);
                break;
            case "StairIdle":
                animator.SetBool("StairRun", false);
                animator.SetBool("StairRest", true);
                animator.SetBool("StairRest2", false);
                break;
            case "StairIdle2":
                animator.SetBool("StairRun", false);
                animator.SetBool("StairRest", false);
                animator.SetBool("StairRest2", true);
                break;
        }
    }
}