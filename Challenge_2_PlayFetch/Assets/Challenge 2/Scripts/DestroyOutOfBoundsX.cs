using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -42;
    private float bottomLimit = -5;

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if out of bound
        if(transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
        
        // Destroy balls if out of bound
        else if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }

    }
}
