using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Control the enemy behaviour

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f; //enemy speed

    private Rigidbody enemyRigidbody;

    private GameObject playerReference;


    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();

        playerReference = GameObject.Find("Player"); //Get the reference to our player
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (playerReference.transform.position - transform.position).normalized;
        //The direction the enemy goes is the difference between its position and the player's position
        // (playerReference.transform.position - transform.position) = the direction we want
        // .normalized = no matter how far/close the enemy position is, it will always come at that speed

        enemyRigidbody.AddForce(lookDirection * speed);

        //If they fall of the platform, destroy enemies
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }


    }
}
