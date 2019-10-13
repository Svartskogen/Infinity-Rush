using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject boostPrefab;

    public int numberOfPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;

    private int boostCounter;
    public int boostEach;

    // Start is called before the first frame update
    void Start()
    {
        boostCounter = 0;
        Vector3 spawnPosition = new Vector3();
        for(int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = (Random.Range(-spawnPosition.x,spawnPosition.x) * 0.5f + Random.Range(-levelWidth, levelWidth) * 1.5f) / 2;
            boostCounter++;
            if(boostCounter % boostEach == 0)
            {
                Instantiate(boostPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
