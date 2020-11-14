using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the player's movement and jetpacking.
/// </summary>
public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    public bool IsJetpacking = false;

    Rigidbody2D rb;

    float movement = 0f;
    float jetPackThrust;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.Playing())
            movement = Input.GetAxis("Horizontal") * movementSpeed;
    }

    void FixedUpdate()
    {
        if (IsJetpacking)
        {
            Vector2 velocity;    
            velocity.y = jetPackThrust; //Jittery TODO FIX, move to Update and use the transform to move it in steps.
            velocity.x = movement;
            rb.velocity = velocity;
        }
        else
        {
            Vector2 velocity = rb.velocity;
            velocity.x = movement;
            rb.velocity = velocity;
        }
    }
    /// <summary>
    /// Used by <see cref="PlayerJetpack"/> to set the thrust.
    /// </summary>
    public void SetJetpackThrust(float value)
    {
        jetPackThrust = value;
    }
}
