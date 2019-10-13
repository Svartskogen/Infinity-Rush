using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    public int maxHealth;
    public Sprite dedoSprite;

    private ParticleSystem particleSystem;
    private BoxCollider2D collider;
    private int recordHeight;
    private AudioSource audioSource;
    private void Awake()
    {
        health = maxHealth;
    }
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        collider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        PlayerKillLimit.PlayerKill += PlayerKillLimit_PlayerKill;
    }

    private void PlayerKillLimit_PlayerKill(object sender, System.EventArgs e)
    {
        KillPlayer();
    }

    public int GetHealth()
    {
        return health;
    }
    public void DamagePlayer(int amount)
    {
        particleSystem.Play();
        health -= amount;
        if(health <= 0)
        {
            PlayerKillLimit.triggerEventStatic();
        }
    }
    void KillPlayer()
    {
        audioSource.Play();
        PlayerKillLimit.PlayerKill -= PlayerKillLimit_PlayerKill;
        GetComponent<SpriteRenderer>().sprite = dedoSprite;
        //Debug.Log("dedo");
        collider.enabled = false;
        recordHeight = (int)transform.position.y;
        HighScoreSet.SetHighscore(recordHeight + HighScoreSet.gameScore);
    }
}
