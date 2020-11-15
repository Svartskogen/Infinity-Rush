using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple script which handles game init and sets the player's <see cref="Rigidbody2D"/> constraints
/// </summary>
public class PressKeyToPlay : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            GameManager.StartGame();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            this.enabled = false;
        }
    }
}
