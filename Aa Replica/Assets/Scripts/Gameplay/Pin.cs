using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float pinSpeed = 50f;
    
    private bool isPinned = false;

    private Rigidbody2D pinRigidbody;
    private Animator animator;

    //For ReturnRandomNumber() 
    // int minValue = -1;
    // int maxValue = 2;

    // Start is called before the first frame update
    void Start()
    {
            pinRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPinned)
        {
            pinRigidbody.MovePosition(pinRigidbody.position + Vector2.up * pinSpeed * Time.deltaTime);
        }
    }

    //Check for collisions
   private void OnTriggerEnter2D(Collider2D collider)
   {
       if(collider.tag == "Rotator")
       {
            transform.SetParent(collider.transform);
            isPinned = true;
            
            Score.score -= 1; //decrease the score text as we shoot

            FindObjectOfType<GameManager>().LevelPassed();

            FindObjectOfType<Score>().DisableScoreText();
           
        //    collider.GetComponent<Rotator>().speed *= ReturnRandomNumber();

       }
       else if (collider.tag == "Pin")
       {
        //    The game has ended if we hit a pin
            FindObjectOfType<GameManager>().EndGame();
       }

       Debug.Log("Collided with: " + collider.gameObject.name);
   }


//Return a random number to change the rotation of the Rotator
//    private int ReturnRandomNumber()   
//    {
//        int number = Random.Range(minValue, maxValue);
//        return number;
//    }
}

