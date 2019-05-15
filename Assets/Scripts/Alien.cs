using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public int seeds = 0;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Seed")
        {
            seeds++;
            Destroy(collision.gameObject);
        }
    }
}
