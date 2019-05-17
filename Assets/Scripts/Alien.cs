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
    private AudioSource audioSource;

    public AudioClip pickUpSound;
    public AudioClip jumpSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController2D>();
        gc = FindObjectOfType<GameController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (gc.gameOver)
        {
            return;
        }

        if(seeds < 0)
        {
            seeds = 0;
        }

        seedCount.text = "= " + seeds.ToString("000");

        anim.SetBool("Jump", !characterController.grounded);

        transform.Translate(Vector2.right * gc.runSpeed * Time.deltaTime);
        if (Input.GetButtonDown("Jump"))
        {
            if (characterController.grounded)
            {
                audioSource.PlayOneShot(jumpSound);
            }

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
            audioSource.PlayOneShot(pickUpSound);
            seeds++;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Bee")
        {
            gc.gameOver = true;
        }
    }
}
