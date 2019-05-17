using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    public int minFlowers;
    public int maxFlowers;
    public LayerMask groundLayer;
    public Flower flower;
    public ParticleSystem bloom;
    public GameObject growPoint;

    private Alien alien;
    private CharacterController2D characterController;
    private GameController gc;
    private AudioSource audioSource;

    private bool seed;
    private bool step;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gc = FindObjectOfType<GameController>();
        alien = GetComponentInParent<Alien>();
        characterController = GetComponentInParent<CharacterController2D>();
    }

    private void Update()
    {
        if(transform.rotation.z > 0 && !seed && characterController.grounded)
        {
            if (!step)
            {
                step = true;
                audioSource.Play();
            }

            if(alien.seeds > 0)
            {
                alien.seeds -= 2;
                seed = true;
                GrowFlowers();
            }

        }

        if(transform.rotation.z < 0)
        {
            step = false;
            seed = false;
        }
    }

    void GrowFlowers()
    {
        bloom.Play();
        int numberToGrow = Random.Range(minFlowers, maxFlowers);
        gc.flowersGrown += numberToGrow;
        for (int i = 0; i < numberToGrow; i++)
        {
            float randomX = Random.Range(-2f, 2f);
            Instantiate(flower, new Vector2(growPoint.transform.position.x + randomX, growPoint.transform.position.y), Quaternion.identity);
        }
    }
}
