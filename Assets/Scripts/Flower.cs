using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spr;
    private Camera cam;
    public float dist;

    private void Awake()
    {
        cam = Camera.main;
        spr = GetComponent<SpriteRenderer>();
        int randomIndex = Random.Range(0, sprites.Length);
        spr.sprite = sprites[randomIndex];
    }

    void Update()
    {
        dist = cam.transform.position.x - transform.position.x;
        if(dist > cam.orthographicSize * 2)
        {
            Destroy(gameObject);
        }
    }
}
