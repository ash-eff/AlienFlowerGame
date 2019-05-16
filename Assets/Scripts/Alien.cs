using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Alien : MonoBehaviour
{
    public int seeds;
    public TextMeshProUGUI seedCount;

    private bool jump;
    private CharacterController2D characterController;
    private GameController gc;
    private Animator anim;

    private void Awake()
    {
        characterController = GetComponent<CharacterController2D>();
        gc = FindObjectOfType<GameController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(seeds < 0)
        {
            seeds = 0;
        }

        seedCount.text = "= " + seeds.ToString("000");

        anim.SetBool("Jump", !characterController.grounded);

        transform.Translate(Vector2.right * gc.runSpeed * Time.deltaTime);
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

        if (collision.tag == "Bee")
        {
            gc.gameOver = true;
        }
    }
}
