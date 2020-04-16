using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool HasShield = false;
    private int health;
    public int maxHealth;
    public Sprite dedoSprite;

    public ParticleSystem bloodHitPS;
    private BoxCollider2D collider;
    public BoxCollider2D extraCollider;
    private int recordHeight;
    private AudioSource audioSource;
    public SpriteRenderer shieldVisual;
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
                PlayerKillLimit.triggerEventStatic();
            }
        }
    }
    void KillPlayer()
    {
        audioSource.Play();
        PlayerKillLimit.PlayerKill -= PlayerKillLimit_PlayerKill;
        GetComponent<SpriteRenderer>().sprite = dedoSprite;
        //Debug.Log("dedo");
        collider.enabled = false;
        extraCollider.enabled = false;
        recordHeight = (int)transform.position.y;
        HighScoreSet.SetHighscore(recordHeight + HighScoreSet.gameScore);
    }
}
