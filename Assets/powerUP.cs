using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUP : MonoBehaviour
{

    public float cooldown = 4;
    private float cooldownTimer;
    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if(cooldownTimer < 0)
        {
            speedUpSpawner.canSpawn = true;
            Destroy(gameObject);
        }
    }
}
