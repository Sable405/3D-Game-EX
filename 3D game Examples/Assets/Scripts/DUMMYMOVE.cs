using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DUMMYMOVE : MonoBehaviour
{
   
  
   public bool IsJumping;
    private Rigidbody playerRb;

    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;

    public float turnSpeed = 20f;

    public float movementSpeed;

    private Rigidbody _rigidbody;
 
    private Vector3 _movement;
    Quaternion m_Rotation = Quaternion.identity;

    private Vector3 _defaultGravity = new Vector3(0f, -9.81f, 0);



    public GameObject checkpointAreaObject;

    public bool isAtCheckpoint = false;

    public Vector3 _startingPosition;

    Animator _animator; 

  
    public float Out =10;
    void Start ()
    {

      
        _animator = GetComponent<Animator>();
        Physics.gravity = _defaultGravity;

        _rigidbody = GetComponent<Rigidbody> ();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *=gravityModifier;
     
        
         
    }
void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
         
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            IsJumping = true; 
        }

      //  if(transform.position.y < Out)
       // {
        //    if(isAtCheckpoint)
          //  {
         //       transform.position = _startingPosition; 
          //  }
           // else
            //{
            //    transform.position = _startingPosition;
            //}
        //}

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            IsJumping = false; 
        }
     //  if (collision.gameObject.CompareTag("Outta"))
      // {
      //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      // }
    }


    void FixedUpdate ()
    {
      
        
        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");
        
        _movement.Set(horizontal, 0f, vertical);
        _movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool IsWalking = hasHorizontalInput || hasVerticalInput;

        _animator.SetBool("IsWalking", IsWalking);
        _animator.SetBool("IsJumping", IsJumping);
        _rigidbody.MovePosition(_rigidbody.position + _movement * movementSpeed * Time.deltaTime);
        _rigidbody.MoveRotation(m_Rotation);

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, _movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }
   // void OnTriggerEnter(Collider other)
    //{
      //  if(other.gameObject == checkpointAreaObject)
      //  {
      //      isAtCheckpoint = true;
      //      _startingPosition = checkpointAreaObject.transform.position;
      //  }
   // }


}