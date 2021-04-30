using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float obstacleSpeed = 25;

    //Get a reference on our PlayerController script
    private PlayerController playerControllerScript;

    //Get a left bound for destroying objects that get beyond it
    private float leftBound = -11;

    // Start is called before the first frame update
    void Start()
    {
        //Set the variable to the player controller object on our player game object in our scene
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * obstacleSpeed);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {   //We're using the CompareTag because otherwise it deletes everything that gets
            //past the left bound (including the background)
            Destroy(gameObject);
        }
        
    }
}
