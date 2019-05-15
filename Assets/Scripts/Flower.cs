using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spr;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        int randomIndex = Random.Range(0, sprites.Length);
        spr.sprite = sprites[randomIndex];

    }

    void Update()
    {
        transform.Translate(-Vector3.right * 5 * Time.deltaTime);

        if(transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }
}
