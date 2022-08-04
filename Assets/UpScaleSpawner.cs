using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpScaleSpawner : MonoBehaviour
{

    public float cooldown = 5;
    private float cooldownTimer;

    public GameObject upScaleFabs;

    public static bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        cooldownTimer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {

        if (canSpawn)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer > 0) return;

            cooldownTimer = cooldown;


                var position = new Vector3(Random.Range(-7f, 7f), 0, Random.Range(-3.5f, 3.5f));
                Instantiate(upScaleFabs, position, Quaternion.identity);

            canSpawn = false;

        }

    }
}
