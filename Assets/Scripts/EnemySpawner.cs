using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple enemy spawn manager.
/// Supports a single type of enemy and spawns it after a slightly variable amount of time.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    private bool side;
    private float cooldown;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        side = false;
        cooldown = Time.time + 10f;
    }

    void Update()
    {
        if(GameManager.Playing() && Time.time > cooldown)
        {
            cooldown = Time.time + Random.Range(3, 10);
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        Vector3 spawnPoint = player.position;
        spawnPoint.x = -10;
        if (side)
        {
            spawnPoint.x = 10;
        }
        spawnPoint.y += 8;
        side = !side;
        Instantiate(enemy, spawnPoint, Quaternion.identity);
    }
}
