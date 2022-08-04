using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPaddle : MonoBehaviour
{

    public float cooldown = 4;
    private float cooldownTimer;
    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer = cooldown;
        UpSpeedSpawner.canSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0)
        {
            UpSpeedSpawner.canSpawn = true;
            Destroy(gameObject);
        }
    }
}
