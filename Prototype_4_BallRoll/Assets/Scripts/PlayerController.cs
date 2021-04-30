using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interaction with player

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody playerRigidbody; //Get a reference to the Rigidbody component
    public float speed =5.0f;

    private GameObject focalPoint;

    public bool hasPowerup = false;

    private float powerUpStrength = 15.0f; //multiply the collision with an enemy
                                           //when powerup is on

    public GameObject powerupIndicator; //Create a reference to the power up indicator

    public Vector3 offset = new Vector3(0, -0.605f, 0);



    // Start is called before the first frame update
    void Start()
    {
        
        playerRigidbody = GetComponent<Rigidbody>(); //Get the rigidbody component

        focalPoint = GameObject.Find("FocalPoint"); //Get a reference to the Focal Point object
    }

    // Update is called once per frame
    void Update()
    {
        //Get input
        float forwardInput = Input.GetAxis("Vertical");
        

        //Add force to the player
        playerRigidbody.AddForce(focalPoint.transform.forward * forwardInput * speed);

        //set the position of the powerupIndicator to the player position
        powerupIndicator.gameObject.transform.position = transform.position + offset;
    }

    //Destroy the Powerup gem on collision
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    //Countdown for the Powerup
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7); //waits for a certain ammount of time before executing next line
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            //The direction that we should send the enemy away from the player


            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);

            Debug.Log("Collided with " + collision.gameObject + 
                " with Powerup set to " + hasPowerup);
        }      
    }

}
