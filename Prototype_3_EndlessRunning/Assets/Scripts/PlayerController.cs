using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declare a RigidBody type variable
    private Rigidbody playerRigodbody;

    public float jumpForce = 10;

    //Change the gravity the way we want it using this variable
    public float gravityModifier;

    //Use this for disabling multiple jump
    public bool isOnGround = true;

    public bool gameOver = false;

    //Get a reference to our animator
    private Animator playerAnimation;

    //Create  Particle System variables for explosion and dirt splatter
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtSplatter;

    //Create some variables to store the sounds for jumping and crashing
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;


    // Start is called before the first frame update
    void Start()
    {
        //Getting the component
        playerRigodbody = GetComponent<Rigidbody>();

        //playerRigodbody.AddForce(Vector3.up * 1000);

        //Change the gravity of our physics
        Physics.gravity *= gravityModifier;

        //Get the Animator component
        playerAnimation = GetComponent<Animator>();

        //Get the AudioSource component
        playerAudio = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver != true)
        {
            playerRigodbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false; // not on the ground anymore
            dirtSplatter.Stop(); //If player jumps, stop the dirt splatter
            
            playerAnimation.SetTrigger("Jump_trig"); //activate the jump_trig when we press Space
            playerAudio.PlayOneShot(jumpSound, 1.0f); //play the sound when jumping

        }

      
    }


    //Change the boolean value back to true once the player hits the ground
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")) //If we collide with a gameObject that
        {                                             //has the "Ground" tag
            isOnGround = true;
            dirtSplatter.Play(); //Play dirt splatter as long as player is on ground
        } else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);

            explosionParticle.Play(); //When the player hits the obstacle, play the explosionParticle
            dirtSplatter.Stop();  //Stop the dirt splatter efect after hitting obstacle
            playerAudio.PlayOneShot(crashSound, 1.0f); //play the sound when collision with obstacle
        }
    }
}
