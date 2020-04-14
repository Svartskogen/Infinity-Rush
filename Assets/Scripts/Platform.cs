using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;
    public bool destroy;
    private Transform camera;
    private void Start()
    {
        camera = Camera.main.transform;
    }
    private void Update()
    {
        if(destroy && camera.position.y - 10 > transform.position.y)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Player player = collision.collider.GetComponent<Player>();
            if (player != null)
            {
                if (!player.IsJetpacking)
                {
                    Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        Vector2 velocity = rb.velocity;
                        velocity.y = jumpForce;
                        rb.velocity = velocity;
                    }
                }
            }


            Bullet bullet = collision.collider.GetComponent<Bullet>();
            if(bullet != null)
            {
                bullet.LevelUpBullet();
            }
        }
    }
}
