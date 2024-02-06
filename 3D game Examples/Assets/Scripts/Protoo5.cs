using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protoo5 : MonoBehaviour
{
  private Rigidbody playerRb;

    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    float horizontalInput;
    float verticalInput;
    public float Gravity;
    private Rigidbody _playerRigidBody;
    public float forceMultiplier;
    // public GameObject winTextObjectShadow;

    private int count;


    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
      playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;


    
    }

    void Update()
    {


        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, Gravity, verticalInput);

        _playerRigidBody.AddForce(movement * forceMultiplier);

        if (Input.GetKeyDown(KeyCode.R))
        {
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //SceneManager.LoadScene(0);
        }

    if (Input.GetKeyDown(KeyCode.Space))
        {
         
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

    
      

    }

      private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
          
        }
       
    }

}

