using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigFantKI : MonoBehaviour
{

    public Transform ball;
    public float ballPosY;
    public Transform digFant;
    public Rigidbody2D digFantRB;
    public float difficulty;
    public float difficultyincrease;
    

    // Start is called before the first frame update
    void Start()
    {
        
        //link ball
        ball = GameObject.Find("Ball").transform;
        digFant = gameObject.transform;
        digFantRB = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        difficultyincrease = GameObject.Find("Ball").GetComponent<BallKI>().scorePlayer1;
        Debug.Log((difficulty + difficultyincrease)/4);
        ballPosY = ball.position.y;

        if (ballPosY > digFant.position.y + 0.2)
        {
            //move DigFant up
            digFantRB.velocity = new Vector2(0, difficulty + difficultyincrease/4);
        }
        else if(ballPosY < digFant.position.y -0.2)
        {
            //move DigFant down
            digFantRB.velocity = new Vector2(0, -difficulty - difficultyincrease/4);
        }
        else
        {
            digFantRB.velocity = new Vector2(0, 0);
        }
    }
    
}
