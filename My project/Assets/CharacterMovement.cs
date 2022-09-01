using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
 
  public float speed = 5f;

  public float moveSpeed; 

  float horizontalInput;

  float verticalInput;  

  public float jumpforce = 5;   
    
  Vector3 moveDirection;

  public Transform orientation; 

  Rigidbody rb; 

   private void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MyInput(); 

      if (Input.GetKeyDown(KeyCode.Space))
       {
        rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
       }
    }
     
    private void  FixedUpdate()
    {
        MovePlayer(); 
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); 
        verticalInput = Input.GetAxisRaw("Vertical"); 
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force); 
    }

  
   
}




 

