using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;

  public float moveSpeed; 

  float horizontalInput;

  float verticalInput;    
    
  private Vector3 moveDirection;

  private Vector2 currentInput; 

  public Transform orientation; 

  Rigidbody rb; 

  public float maxFuel = 4f;

    public float thrustForce = 0.5f;

 public Rigidbody rigid;

 public Transform groundedTransform;


 private float curFuel;

   private void Start()
    {
      rb = GetComponent<Rigidbody>();
       curFuel = maxFuel;
    }

    private void Update()
    {
        MyInput(); 

        if (Input.GetAxis("Jump") > 0.5f && curFuel > 0.5f)
        {
            curFuel -= Time.deltaTime;
            rigid.AddForce(rigid.transform.up * thrustForce, ForceMode.Impulse);
            
        }
        else if(Physics.Raycast(groundedTransform.position, Vector3.down, 0.05f, LayerMask.GetMask("Grounded")) && curFuel < maxFuel)
        {
            curFuel += Time.deltaTime;
           
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

        rb.AddForce(moveDirection.normalized * moveSpeed * 5f, ForceMode.Force); 
   }

   
}




 

