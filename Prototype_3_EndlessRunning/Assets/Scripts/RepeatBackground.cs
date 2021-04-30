using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We'll use this script to create the illusion
//of an infinite background

public class RepeatBackground : MonoBehaviour
{
    //Create a Vector3 variable to store the background starting position
    private Vector3 startPosition;

    private float repeatWidth; //We're trying to get to the middle of the background


    // Start is called before the first frame update
    void Start()
    {
        //Set the startPosition equal to the background current position
        startPosition = transform.position;

        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        //Getting the component x size and dividing it by 2
        //to get the exact middle of the background

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            //Reset the entire position of the background back to the start position
            transform.position = startPosition;
        }
    }
}
