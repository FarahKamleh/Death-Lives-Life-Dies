﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMovement : MonoBehaviour
{
    // define the forward axis 
    public CAVE2.Axis forwardAxis = CAVE2.Axis.LeftAnalogStickUD;

    // reference animator
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        // print the value
        // Debug.Log(CAVE2.Input.GetAxis(2, forwardAxis));

        // if moving forward or backwards
        if (CAVE2.Input.GetAxis(2, forwardAxis) != 0)
        {
            // turn on running animation
            animator.SetBool("IsRunning", true);
        }
        // if in place
        else if (CAVE2.Input.GetAxis(2, forwardAxis) == 0)
        {
            // turn off running
            animator.SetBool("IsRunning", false);
        }
    }
}
