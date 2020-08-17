using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public bool isplayer;
    void FixedUpdate()
    {
        if (isplayer){
            float input = Input.GetAxisRaw("Vertical");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, input) * speed;
        }
        else
        {
            float input = Input.GetAxisRaw("Vertical2");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, input) * speed;
        }

        
    }
}
