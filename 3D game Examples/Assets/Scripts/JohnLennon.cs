using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnLennon : MonoBehaviour
{
   // public InputAction MoveAction;
    
    public float turnSpeed = 20f;

    public float movementSpeed;
 //   Animator m_Animator;
    private Rigidbody _rigidbody;
   // AudioSource m_AudioSource;
   private Vector3 _movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start ()
    {
    //    m_Animator = GetComponent<Animator> ();
        _rigidbody = GetComponent<Rigidbody> ();
       // m_AudioSource = GetComponent<AudioSource> ();
        
        //MoveAction.Enable();
    }

    void FixedUpdate ()
    {
       // var pos = MoveAction.ReadValue<Vector2>();
        
        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");
        
        _movement.Set(horizontal, 0f, vertical);
        _movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
       // m_Animator.SetBool ("IsWalking", isWalking);
        _rigidbody.MovePosition(_rigidbody.position + _movement * movementSpeed * Time.deltaTime);
        _rigidbody.MoveRotation(m_Rotation);
     //   if (isWalking)
     //   {
         //   if (!m_AudioSource.isPlaying)
         //   {
         //       m_AudioSource.Play();
           // }
     //   }
      //  else
       // {
       //     m_AudioSource.Stop ();
       // }

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, _movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

   // void OnAnimatorMove ()
   // {
   //     m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
     //   m_Rigidbody.MoveRotation (m_Rotation);
 //  }
}