using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private GameController gc;
    private Collider2D coll;
    private float resetPosX;
    private Camera cam;
    public float distX;
    public float boundSizeX;

    private void Awake()
    {
        cam = Camera.main;
        coll = GetComponent<Collider2D>();
        gc = FindObjectOfType<GameController>();
        boundSizeX = coll.bounds.size.x;
    }

    private void Update()
    {
        distX = cam.transform.position.x - transform.position.x;
        if(distX > boundSizeX)
        {
            resetPosX = cam.transform.position.x + boundSizeX;
            transform.position = new Vector2(Mathf.RoundToInt(resetPosX), transform.position.y);
        }
    }
}
