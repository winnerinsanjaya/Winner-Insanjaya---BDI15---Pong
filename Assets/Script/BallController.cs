using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed, waitTime;
    private float speedX, speedY;
    private Rigidbody2D rig;
    public float powerup;
    public float powerUpTime;
    private float powerUpTimer;

    private bool powerUpAct;

    private void Start()
    {
        speedX = speed * 50;
        speedY = speed * 50;

        rig = GetComponent<Rigidbody2D>();
        resetPong();

        powerUpTimer = powerUpTime;
    }

    void Update()
    {
    }

    public void resetPong()
    {
        rig.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        Invoke("moveBall", waitTime);
    }
    public void moveBall()
    {
        int dirBall = Random.Range(0, 2);
        if (dirBall == 0)
        {
            rig.AddForce(new Vector2(-speedX, speedY));
        }
        else
        {
            rig.AddForce(new Vector2(speedX, speedY));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "counter")
        {
            resetPong();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "gawangkiri")
        {
            ScoreScript.score2 += 1;
            resetPong();
        }

        if (collision.tag == "gawangkanan")
        {
            ScoreScript.score1 += 1;
            resetPong();
        }

        if (collision.tag == "powerup")
        {
            activePowerUp();
            Destroy(collision.gameObject);
            speedUpSpawner.canSpawn = true;

        }

        if (collision.tag == "paddlekiri")
        {
            ScoreScript.lastPaddle = "paddlekiri";
            //Debug.Log("kiri");
        }

        if (collision.tag == "paddlekanan")
        {
            ScoreScript.lastPaddle = "paddlekanan";
            //Debug.Log("kanan");
        }

        if (collision.tag == "uppaddle")
        {
            if(ScoreScript.lastPaddle == "paddlekanan")
            {
                GameObject paddleKa = GameObject.Find("Player2");
                paddleKa.GetComponent<PaddleController>().upScale();
            }

            if (ScoreScript.lastPaddle == "paddlekiri")
            {
                GameObject paddleKa = GameObject.Find("Player1");
                paddleKa.GetComponent<PaddleController>().upScale();
            }


           Destroy(collision.gameObject);
            UpScaleSpawner.canSpawn = true;
        }

        if (collision.tag == "speedpaddle")
        {
            if (ScoreScript.lastPaddle == "paddlekanan")
            {
                GameObject paddleKa = GameObject.Find("Player2");
                paddleKa.GetComponent<PaddleController>().upSpeed();
            }

            if (ScoreScript.lastPaddle == "paddlekiri")
            {
                GameObject paddleKa = GameObject.Find("Player1");
                paddleKa.GetComponent<PaddleController>().upSpeed();
            }


            Destroy(collision.gameObject);
            UpSpeedSpawner.canSpawn = true;
        }
    }


    public void activePowerUp()
    {
        rig.velocity *= powerup;
        Debug.Log("speedup");
    }

}
