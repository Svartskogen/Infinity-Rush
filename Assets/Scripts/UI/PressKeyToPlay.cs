using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyToPlay : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            GameManager.StartGame();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            this.enabled = false;
        }
    }
}
