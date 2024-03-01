using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picks : MonoBehaviour
{
    public GameObject player;
    private bool isNearItem = false;
    private GameObject item;
    public float distanceFromPlayer = 1.0f; // Distance from the player to hold the item

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isNearItem = true;
            item = gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isNearItem = false;
            item = null;
        }
    }

    void Update()
    {
        if (isNearItem && Input.GetKeyDown(KeyCode.E))
        {
            if (item.transform.parent == null) // If the item is not currently held
            {
                // Calculate the position in front of the player
                Vector3 newPosition = player.transform.position + player.transform.forward * distanceFromPlayer;
                // Set the item's position
                item.transform.position = newPosition;
                // Set the item's rotation to match the player's rotation
                item.transform.rotation = player.transform.rotation;
                // Set the item's parent to the player to pick it up
                item.transform.parent = player.transform;
            }
            else // If the item is already held
            {
                // Set the item's parent to null to detach it from the player and drop it
                item.transform.parent = null;
            }
        }
    }
}
