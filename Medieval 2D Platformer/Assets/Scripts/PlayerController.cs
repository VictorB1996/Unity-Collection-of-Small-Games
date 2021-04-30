using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float switchSprite = -1;
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerBoxCollider;
    private Animator playerAnimation;
    private bool facingRight;
    private bool isAttacking;
    private bool isRolling;

    [SerializeField]
    private Transform[] groundPoints; 

    [SerializeField]
    private float checkGroundRadius;

    [SerializeField]
    private LayerMask groundLayerMask;

    private bool isGrounded;
    private bool isJumping;

    [SerializeField]
    private float jumpForce;



    public float movementSpeed = 5f;


    


    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterInput();
    }

    void FixedUpdate() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        CharacterMovement(horizontalInput);
        CharacterFlip(horizontalInput);
        CharacterAttack();

        ResetValues();    

        
        // Debug.Log(playerRigidbody.velocity);
    }


   

    
    //Handles player movement
    private void CharacterMovement(float horizontalInput)
    {
        //if not attacking, then we can run
        if(!playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") &&!isJumping)
        {
            playerRigidbody.velocity = new Vector2(horizontalInput * movementSpeed, playerRigidbody.velocity.y);
            playerAnimation.SetFloat("Speed", Mathf.Abs(horizontalInput));
        }
       

        if(isGrounded && isJumping)
        {
            isGrounded = false;
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        }

        //Handle Rolling
        if(isRolling && !playerAnimation.GetCurrentAnimatorStateInfo(0).IsTag("Roll"))
        {
            playerAnimation.SetBool("Roll", true);
        }
        else 
        {
            playerAnimation.SetBool("Roll", false);
        }

        //Temporarly disable the character box collider when he is rolling
        if(playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
            playerBoxCollider.enabled = false;
        }
        else
        {
            playerBoxCollider.enabled = true;
        }

        //Handle Jumping
        playerAnimation.SetFloat("Height", playerRigidbody.velocity.y);
        playerAnimation.SetBool("isGrounded", isGrounded);

    }


    //Handles sprite flip
    private void CharacterFlip(float horizontalInput)
    {
        if(horizontalInput > 0 && !facingRight || horizontalInput < 0 && facingRight 
            && !playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Attack_1"))
        {
            facingRight = !facingRight;
            Vector3 playerScale = transform.localScale;
            playerScale.x *= switchSprite;
            transform.localScale = playerScale;
        }
    }

     //Handles Character Input
    private void CharacterInput()
    {
        //Checks for attack input
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            isAttacking = true;
        }

        //Check for Rolling input
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            isRolling = true;
        }

        //Checks for jump input
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    //Handles Attack
    private void CharacterAttack()
    {
        if(isAttacking && isGrounded)
        {
            playerAnimation.SetTrigger("Attack");
            playerRigidbody.velocity = Vector2.zero;
        }
    }

    //Reset Values
    private void ResetValues()
    {
        isAttacking = false;
        isRolling = false;
        isJumping = false;
    }



    // ################################ First try for collision detection with ground
    //Checks ground collision
    private bool IsGrounded()
    {
        if(playerRigidbody.velocity.y <= 0)
        {
            foreach(Transform point in groundPoints)
            {
                //Every time players hits the ground, store that collider
                Collider2D [] groundColliders = Physics2D.OverlapCircleAll(point.position, checkGroundRadius, groundLayerMask);
                for (int i = 0; i < groundColliders.Length; i++)
                {
                    if(groundColliders[i].gameObject != gameObject) //the player always collides with himself, so we do not want that
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }


   
    
}
