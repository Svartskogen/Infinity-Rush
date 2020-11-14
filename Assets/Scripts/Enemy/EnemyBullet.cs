using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script responsible for handling the bullet movement, collision and damaging the <see cref="PlayerHealth"/>
/// </summary>
public class EnemyBullet : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float force;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the collision has a PlayerHealth script (the Player) damage it, otherwise do nothing.
        PlayerHealth reference = collision.GetComponent<PlayerHealth>();
        if(reference != null)
        {
            reference.DamagePlayer(damage);
            Destroy(gameObject);
        }
    }
}
