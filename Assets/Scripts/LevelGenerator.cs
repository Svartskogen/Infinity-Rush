using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [System.Serializable]
    public enum GeneratorMode { Simple, PositionBased};

    public GeneratorMode generatorMode;
    public GameObject platformPrefab;
    public GameObject boostPrefab;

    public int numberOfPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;

    public int boostEach;
    private int boostCounter = 0;

    private Transform player;
    Vector2 lastPosition = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {
        if(generatorMode == GeneratorMode.Simple)
        {
            boostCounter = 0;
            Vector3 spawnPosition = new Vector3();
            for (int i = 0; i < numberOfPlatforms; i++)
            {
                spawnPosition.y += Random.Range(minY, maxY);
                spawnPosition.x = (Random.Range(-spawnPosition.x, spawnPosition.x) * 0.5f + Random.Range(-levelWidth, levelWidth) * 1.5f) / 2;
                boostCounter++;
                if (boostCounter % boostEach == 0)
                {
                    Instantiate(boostPrefab, spawnPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
                }

            }
        }
        else if(generatorMode == GeneratorMode.PositionBased)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            boostCounter = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(generatorMode == GeneratorMode.PositionBased)
        {
            if(player.position.y + 10 > lastPosition.y)
            {
                Vector3 spawnPosition = new Vector3(lastPosition.x,lastPosition.y);
                spawnPosition.y += Random.Range(minY, maxY);
                spawnPosition.x = (Random.Range(-spawnPosition.x, spawnPosition.x) * 0.5f + Random.Range(-levelWidth, levelWidth) * 1.5f) / 2;
                boostCounter++;
                if (boostCounter % boostEach == 0)
                {
                    Instantiate(boostPrefab, spawnPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
                }
                lastPosition = spawnPosition;
            }
        }
    }
}
