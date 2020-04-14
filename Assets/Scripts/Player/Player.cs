using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;

    Rigidbody2D rb;

    float movement = 0f;
    public bool IsJetpacking = false;
    float jetPackThrust;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.Playing())
        {
            movement = Input.GetAxis("Horizontal") * movementSpeed;
        }
        else
        {
            //movement = 0;
        }

    }

    void FixedUpdate()
    {
        if (IsJetpacking)
        {
            Vector2 velocity;    
            velocity.y = jetPackThrust; //Jittery TODO FIX, moverlo a update y usar el transform para moverlo en steps
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
    public void SetJetpackThrust(float value)
    {
        jetPackThrust = value;
    }
}
