using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    // Local rigidbody variable to hold a reference to the attached Rigidbody2D component
    new Rigidbody2D rigidbody2D;

    public float movementSpeed = 1000.0f;
    public float maxSpeed = 10.0f;
    public Vector2 playerDirection = new Vector2(0.0f, 0.0f);
    public PlayerAnimationController playerAnimationController;

    public GunController gunController;


    void Awake()
    {
        // Setup Rigidbody for frictionless top down movement and dynamic collision
        rigidbody2D = GetComponent<Rigidbody2D>();
 
        rigidbody2D.isKinematic = false;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {
        // Handle user input
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Move(targetVelocity);
        //detect input
        if (targetVelocity != Vector2.zero)
        {
            playerDirection = targetVelocity;
            
        }
        if (Input.GetButtonDown("Jump"))
        {
            gunController.Fire();
        }
        // Update animation
        playerAnimationController.Movement((int)targetVelocity.y, (int)targetVelocity.x);
    }

    void Move(Vector2 targetVelocity)
    {
        rigidbody2D.velocity = Vector2.ClampMagnitude((targetVelocity * movementSpeed) * Time.deltaTime, maxSpeed); // some stuff for the fps player movement (dont clip thru walls)
    }
}

