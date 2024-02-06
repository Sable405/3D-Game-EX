using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    public float movementSpeed = 5f;

    private bool movingRight = true;

    void Update()
    {
        float step = movementSpeed * Time.deltaTime;

        if (movingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition.position, step);
            if (transform.position == endPosition.position)
                movingRight = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition.position, step);
            if (transform.position == startPosition.position)
                movingRight = true;
        }
    }
}


