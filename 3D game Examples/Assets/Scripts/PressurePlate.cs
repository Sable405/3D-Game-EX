using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    
    public bool PressureP = false; 
    public GameObject Doors; 
    public Vector3 down; 

    public DoorMove doorMoveScript; 
    // Start is called before the first frame update
    void Start()
    {
      GameObject Doors = GameObject.Find("Door2");
               doorMoveScript.movingRight = false; 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
      private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          PressureP = true; 
          transform.position = Vector3.down;
         doorMoveScript.movingRight = true; 
            
        }
     
    }
}
