using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUpSpawner : MonoBehaviour
{

    public int jumlahSU;
    public float cooldown = 2;
    private float cooldownTimer;

    public GameObject speedUpfabs;

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
        jumlahSU = Random.Range(1, 3);


        if (canSpawn)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer > 0) return;

            cooldownTimer = cooldown;

            GameObject[] masihada = GameObject.FindGameObjectsWithTag("powerup");
            if(masihada.Length == 0)
            {
                if (jumlahSU == 1)
                {
                    var position = new Vector3(Random.Range(-7f, 7f), 0, Random.Range(-3.5f, 3.5f));
                    Instantiate(speedUpfabs, position, Quaternion.identity);
                }
                if (jumlahSU == 2)
                {
                    var position1 = new Vector3(Random.Range(0f, 7f), 0, Random.Range(0f, 3.5f));
                    Instantiate(speedUpfabs, position1, Quaternion.identity);

                    var position2 = new Vector3(Random.Range(-7f, 0f), 0, Random.Range(-3.5f, 0f));
                    Instantiate(speedUpfabs, position2, Quaternion.identity);
                }

                canSpawn = false;
            } 

            

        }

    }
}
