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

    private bool seed;

    private void Awake()
    {
        gc = FindObjectOfType<GameController>();
        alien = GetComponentInParent<Alien>();
        characterController = GetComponentInParent<CharacterController2D>();
    }

    private void Update()
    {
        if(transform.rotation.z > 0 && !seed && characterController.grounded && alien.seeds > 0)
        {
            alien.seeds -= 2;
            seed = true;
            GrowFlowers();
        }

        if(transform.rotation.z < 0)
        {
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
