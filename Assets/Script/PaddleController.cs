using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public int speed;
    private int defspeed;

    public bool leftPaddle, rightPaddle;

    private KeyCode upKey, downKey;

    private Rigidbody2D rig;

    public Vector3 scale;

    public bool upScaled;
    public bool upSpeeded;

    public float cooldown = 5;
    private float cooldownTimer;

    private void Start()
    {

        defspeed = speed;
        cooldownTimer = cooldown;

        scale = transform.localScale;
        rig = GetComponent<Rigidbody2D>();

        if (leftPaddle)
        {
            Debug.Log("Kecepatan Paddle Kiri : " + speed);
        }
        if (rightPaddle)
        {
            Debug.Log("Kecepatan Paddle Kanan : " + speed);
        }
    }
    private void Update()
    {
        if (leftPaddle)
        {
            upKey = KeyCode.Q;
            downKey = KeyCode.A;
        }

        if (rightPaddle)
        {
            upKey = KeyCode.W;
            downKey = KeyCode.S;
        }


        

            // get input 
            Vector3 movement = GetInput();

        // move object 
        MoveObject(movement);


        if (upScaled)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer > 0) return;

            cooldownTimer = cooldown;
            transform.localScale = scale;
            upScaled = false;
        }

        if (upSpeeded)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer > 0) return;

            cooldownTimer = cooldown;
            speed = defspeed;
            upSpeeded = false;
        }
    }


    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        rig.velocity = movement;
        transform.Translate(movement * Time.deltaTime);
    }

    public void upScale()
    {
        transform.localScale = new Vector3(0.3f, 4f, 1f);
        upScaled = true;
    }

    public void upSpeed()
    {
        speed = defspeed * 2;
        upSpeeded = true;

    }
}
