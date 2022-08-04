using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpScale : MonoBehaviour
{
    public float cooldown = 4;
    private float cooldownTimer;
    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer = cooldown;
        UpScaleSpawner.canSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0)
        {
            UpScaleSpawner.canSpawn = true;
            Destroy(gameObject);
        }
    }
}
