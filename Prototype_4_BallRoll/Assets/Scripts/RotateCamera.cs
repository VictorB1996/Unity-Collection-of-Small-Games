using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script is used for rotating the camera around its focal point

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the camera
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * rotationSpeed);
    }
}
