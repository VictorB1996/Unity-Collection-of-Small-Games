using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We'll use this script to spawn Obstacles

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnLocation = new Vector3(30, 0, 0);

    private float startDelay = 2;     //Start of spawning
    private float repeatRate = 2;     //Repeat rate of spawning

    //Get a reference to our PlayerController script
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        //Atach our variable to the reference of our PlayerControllerScript
        //in the scene
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Function that spawns obstacles
    void SpawnObstacle()
    {
        //By creating the reference to the PlayerController script
        //we can check the gameOver variable status
        if(playerControllerScript.gameOver == false)
        {
            //As long as the gameOver is false, keep creating the obstacles
            Instantiate(obstaclePrefab, spawnLocation, obstaclePrefab.transform.rotation);
        }
        

        

    }


}
