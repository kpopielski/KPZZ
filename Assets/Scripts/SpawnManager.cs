using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] presentPrefabs;
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 8;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
  
    // Start is called before the first frame update
    void Start()
    {
        
            InvokeRepeating("SpawnRandnomPresent", startDelay, spawnInterval);
            InvokeRepeating("SpawnRandnomEnemy", startDelay + 3, spawnInterval + 3);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandnomPresent()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, presentPrefabs.Length);
        Instantiate(presentPrefabs[animalIndex], spawnPos, presentPrefabs[animalIndex].transform.rotation);
    }
    void SpawnRandnomEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}

