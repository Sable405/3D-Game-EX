using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
   public Transform startPosition;
    public Transform endPosition;
    public float movementSpeed = 5f;

    public bool movingRight = false;

    void Start()
    {
        movingRight = false; 
    }

    void Update()
    {
        
        float step = movementSpeed * Time.deltaTime;
    
        if (movingRight == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition.position, step);
           // if (transform.position == endPosition.position)
                //movingRight = true;
        }
       // else
        //{
       //     transform.position = Vector3.MoveTowards(transform.position, startPosition.position, step);
      //      if (transform.position == startPosition.position);
              
       // }
    }
}
