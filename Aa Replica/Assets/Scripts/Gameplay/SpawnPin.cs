using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPin : MonoBehaviour
{
    public GameObject pinPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }


    //Instantiate a pin at the spawner position
    private void Spawn()
    {
        Instantiate(pinPrefab, transform.position, transform.rotation);
    }
}
