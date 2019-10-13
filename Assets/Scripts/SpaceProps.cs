using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceProps : MonoBehaviour
{
    public Transform player;

    public GameObject satellite;
    public int spawnOnHeight;
    private float cooldown;
    private bool inSpace;
    // Start is called before the first frame update
    void Start()
    {
        inSpace = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > cooldown && !inSpace)
        {
            cooldown = Time.time + 5f;
            if(player.position.y > spawnOnHeight)
            {
                inSpace = true;
            }
        }

        if(Time.time > cooldown && inSpace)
        {
            cooldown = Time.time + Random.Range(3, 10);
            Vector3 spawnLocation = player.position;
            int side = Random.Range(0, 2);
            if (side == 1)
            {
                spawnLocation.x = 15;
            }
            else
            {
                spawnLocation.x = -15;
            }
            spawnLocation.y += Random.Range(0,5);

            GameObject sat = Instantiate(satellite, spawnLocation, Quaternion.identity);
            sat.transform.Rotate(new Vector3(0, 0, Random.Range(0, 60)));
            if(spawnLocation.x > 0)
            {
                sat.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10, -30), 0),ForceMode2D.Impulse);
            }
            else
            {
                sat.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(10, 30), 0), ForceMode2D.Impulse);
            }
        }
    }
}
