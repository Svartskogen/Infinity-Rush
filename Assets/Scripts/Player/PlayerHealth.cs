using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the player's movement, shields, hit particles, sfx, death and record height.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    public bool HasShield = false;
    public int maxHealth;
    public Sprite deathSprite;

    private int health;

    public ParticleSystem bloodHitPS;
    public BoxCollider2D extraCollider;
    public SpriteRenderer shieldVisual;

    private BoxCollider2D collider;
    private int recordHeight;
    private AudioSource audioSource;

    private void Awake()
    {
        health = maxHealth;
    }
    void Start()
    {
        bloodHitPS = GetComponent<ParticleSystem>();
        collider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        PlayerKillLimit.PlayerKill += PlayerKillLimit_PlayerKill;
    }
    private void Update()
    {
        if (HasShield)
        {
            shieldVisual.enabled = true;
        }
        else
        {
            shieldVisual.enabled = false;
        }
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
        if (HasShield)
        {
            HasShield = false;
        }
        else
        {
            bloodHitPS.Play(false);
            health -= amount;
            if (health <= 0)
            {
                PlayerKillLimit.TriggerEventStatic();
            }
        }
    }
    void KillPlayer()
    {
        audioSource.Play();
        PlayerKillLimit.PlayerKill -= PlayerKillLimit_PlayerKill;
        GetComponent<SpriteRenderer>().sprite = deathSprite;
        collider.enabled = false;
        extraCollider.enabled = false;
        recordHeight = (int)transform.position.y;
        HighScoreSet.SetHighscore(recordHeight + HighScoreSet.gameScore);
    }
}
