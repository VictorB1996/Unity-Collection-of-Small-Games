using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //We'll create a GameObject array to store our animal prefabs
    public GameObject[] animalPrefabs;


    private float spawnPositionZ = 25;
    private float spawnRangeX = 10;

    private float startDelay = 2;
    private float repeatRate = 1.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
       //Everytime S is pressed, spawn a random animal
       /*
        if(Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
        */
    }

    //Method that spawns random animals at random location
    void SpawnRandomAnimal()
    {
        //Random index in our array
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        //Random location to spawn
        Vector3 spawnLocation = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPositionZ);

        //Spawn animal
        Instantiate(animalPrefabs[animalIndex], spawnLocation, animalPrefabs[animalIndex].transform.rotation);

    }




}
