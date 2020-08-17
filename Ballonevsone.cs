using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Ballonevsone : MonoBehaviour
{
    //variables
    public float speed;
    float scorePlayer1;
    float scoreEnemy;
    public Text txtPlayer1;
    public Text txtEnemy;
    public float pausetime;
    bool quit = false;
    private float realspeed;
    
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

    }


    void Update()
    {
        
    }

    
   //Collision Physics
    private void OnCollisionEnter2D(Collision2D col)
    {
        realspeed = speed + (scorePlayer1/2 + scoreEnemy/2);
        //print(col.gameObject.name);

        if (col.gameObject.name == "Player1")
        {
            //Collision Player1
            float y = HitObject(transform.position, col.transform.position, col.collider.bounds.size.y);
            //Calculate Direction
            Vector2 dir = new Vector2(1, y);
            //Directionvector Physics
            GetComponent<Rigidbody2D>().velocity = dir * realspeed;
        }
        if (col.gameObject.name == "Enemy")
        {
            //collision Enemy
            float y = HitObject(transform.position, col.transform.position, col.collider.bounds.size.y);
            //Calculate Direction
            Vector2 dir = new Vector2(-1, y);
            //Directionvector Physics
            GetComponent<Rigidbody2D>().velocity = dir * realspeed;
        }
        if (col.gameObject.name == "WallRight")
        {
            scorePlayer1 += 1;
            Debug.Log(scorePlayer1);
            txtPlayer1.text = scorePlayer1.ToString();
            //Restart with a pause of pausetime sec
            //Repeat();
            StartCoroutine(Waiter());
        }
        if (col.gameObject.name == "WallLeft")
        {
            scoreEnemy += 1;
            txtEnemy.text = scoreEnemy.ToString();
            //Restart with a pause of pausetime
            //Repeat();
            StartCoroutine(Waiter());

        }
    }

    float HitObject(Vector2 ballPos, Vector2 playerPos, float playerhight)
    {
        return (ballPos.y - playerPos.y) / playerhight;
    }
    IEnumerator Waiter()
    {
        
        float counter = 0;

        realspeed = speed + scorePlayer1 / 2 + scoreEnemy / 2;
        //return to origin
        gameObject.transform.position = new Vector2(0, 0);
        //freeze
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        float waitTime = pausetime;

        while (counter < waitTime)
        {
            counter += Time.deltaTime;
           // Debug.Log("Waited for: " + counter + "seconds");
            if (quit)
            {
                yield break;
            }
            
            
            yield return null;
            
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * speed;


    }
    /*void Repeat()
    {
        realspeed = speed + scorePlayer1/3 +scoreEnemy/3;
        Vector2 temp = new Vector2(0, 0);
        gameObject.transform.position = temp;
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * realspeed;
    }*/
}

