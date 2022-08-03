using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public int speed;

    public bool leftPaddle, rightPaddle;

    private KeyCode upKey, downKey;

    private Rigidbody2D rig;

    private void Start()
    {
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
}
