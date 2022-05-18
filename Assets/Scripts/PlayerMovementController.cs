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
    }

    void Move(Vector2 targetVelocity)
    {        
        // Set rigidbody velocity
        rigidbody2D.velocity = Vector2.ClampMagnitude((targetVelocity * movementSpeed) * Time.deltaTime, maxSpeed); // Multiply the target by deltaTime to make movement speed consistent across different framerates
    }
}

