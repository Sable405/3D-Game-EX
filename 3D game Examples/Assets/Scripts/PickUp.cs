using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject player;
    public bool Picked = false; 
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
}
 void OnTriggerEnter(Collider other)
        {
            
             if (Input.GetKeyDown(KeyCode.E))
        {
            Picked = true;
            Debug.Log("Workin"); 
          transform.parent = player.transform;
             
        }
         if(Picked == true && Input.GetKeyDown(KeyCode.E))
    { 
        Picked = false; 
      transform.parent = null; 
    }
   

}
}

