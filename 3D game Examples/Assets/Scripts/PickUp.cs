using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject Dummy;
    public bool Picked = false; 
   
    // Start is called before the first frame update
    void Start()
    {
    Dummy.gameObject.SetActive(false);  

    }

    // Update is called once per frame
    void Update()
    {
       
}
 void OnTriggerStay(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                if (Input.GetKeyDown(KeyCode.E))
              {
                 Picked = true;
                Debug.Log("Workin"); 
                Dummy.gameObject.SetActive(true);  
             
               }
            if(Picked == true && Input.GetKeyDown(KeyCode.E))
               { 
                 Picked = false; 
                  Dummy.gameObject.SetActive(false);  
                  transform.parent = null; 
                }
   

            }
            
}
}

