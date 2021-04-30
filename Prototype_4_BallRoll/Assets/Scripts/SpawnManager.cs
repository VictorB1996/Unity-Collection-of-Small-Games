using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Use this to spawn enemies

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 10.0f;
    public int enemyCount; //keep track of how many enemies are on the platform

    public int waveNumber = 1; //keeps track of how many enemies to spawn

    public GameObject powerupPrefab;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
        
    }



    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("Enemy in the scene: " + enemyCount);

        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }



    //Method that returns a random spawning location
    private Vector3 RandomSpawnLocation()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);

        return spawnPosition;
    }

    //Method for spawning enemies
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, RandomSpawnLocation(), enemyPrefab.transform.rotation);
        }
    }

    //Method that spawns powerups
    void SpawnPowerup()
    {
        Instantiate(powerupPrefab, RandomSpawnLocation(), powerupPrefab.transform.rotation);
    }
}
