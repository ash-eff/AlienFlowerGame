using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    private bool jump;
    CharacterController2D characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        characterController.Jump(jump);
        jump = false;
    }
}
