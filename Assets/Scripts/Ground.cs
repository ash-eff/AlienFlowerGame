using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.right * 5 * Time.deltaTime);

        if(transform.position.x < -50f)
        {
            transform.position = new Vector2(46, 3);
        }
    }
}
