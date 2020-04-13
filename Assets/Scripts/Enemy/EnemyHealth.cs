using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject explosionFx;
    private int health;
    public int maxHealth;
    public int scoreReward;
    private ParticleSystem particles;
    private void Awake()
    {
        health = maxHealth;
    }
    void Start()
    {
        particles = GetComponent<ParticleSystem>();  
    }


    void Update()
    {

    }


    public int GetHealth()
    {
        return health;
    }
    public void DamageEnemy(int amount)
    {
        particles.Play();
        health -= amount;
        if (health <= 0)
        {
            KillEnemy();
        }
    }
    void KillEnemy()
    {
        HighScoreSet.gameScore += scoreReward;
        Instantiate(explosionFx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
