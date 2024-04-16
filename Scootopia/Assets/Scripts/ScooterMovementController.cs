using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class ScooterMovement : MonoBehaviour{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    void Update()
    {
        // get player input from keyboard to move character forwards, backwards and turns
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // movement direction vector
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        // normalize movement so turning is not faster than forwards motion
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if(characterController.isGrounded){
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
        if (Input.GetButtonDown("Jump")){
            ySpeed = jumpSpeed;

        }
        }
        else{
            characterController.stepOffset = 0;
        }


        // move character in the specificied direction and speed around the map... once char controller introduced this is not needed
        // transform.Translate(movementDirection * speed * Time.deltaTime, Space.World); 
        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;
        characterController.Move(velocity * Time.deltaTime);

        // handles the rotation of the character and ensures player is facing movement direction 
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
 /*  
  attempt at doing it with rigid body... did not work as well
 public float speed;
    private Vector3 movementDirection;
    private Rigidbody rb;

    void Start(){

        rb = GetComponent<Rigidbody>();
    }

    void Update(){

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");        

        movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
    }

    private void FixedUpdate(){
        Vector3 playerSpeed = movementDirection * speed;
        rb.AddForce(playerSpeed);
    }

}  */
