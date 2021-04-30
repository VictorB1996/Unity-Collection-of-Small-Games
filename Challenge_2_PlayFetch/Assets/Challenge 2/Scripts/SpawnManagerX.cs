using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    //private float startDelay = 1.0f;
    //private float spawnInterval = 4.0f;
   

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomAnimal", (Random.Range(3,5)));
    }


    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {

        float repeatRate = Random.Range(3, 5);

        //Random index for the array
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // Generate random spawn position
        Vector3 spawnLocation = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight),
            spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnLocation, ballPrefabs[ballIndex].transform.rotation);

        Invoke("SpawnRandomBall", repeatRate);
    }

}
