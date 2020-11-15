using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple <see cref="Rigidbody2D"/>-based player bullet script, supporting bouncing around platforms.
/// </summary>
public class Bullet : MonoBehaviour
{
    public float force;
    public int damage;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * force, ForceMode2D.Impulse);
    }

    public void LevelUpBullet()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        damage = 3;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyHealth = collision.collider.GetComponent<EnemyHealth>();
            enemyHealth.DamageEnemy(damage);
            Destroy(gameObject);
        }
    }
}
