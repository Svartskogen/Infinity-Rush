using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the jetpack visual and tells the <see cref="Player"/> when its active
/// </summary>
public class PlayerJetpack : MonoBehaviour
{
    public bool hasJetpack = false;
    public float jetPackDuration;
    public float jetPackThrust;

    Player player;
    SpriteRenderer jetpackVisual;
    AudioSource audioSource;
    ParticleSystem particleSystem;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        jetpackVisual = GetComponent<SpriteRenderer>();
        player = GetComponentInParent<Player>();
        player.SetJetpackThrust(jetPackThrust);
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasJetpack || player.IsJetpacking)
        {
            jetpackVisual.enabled = true;
        }
        else
        {
            jetpackVisual.enabled = false;
        }

        if (hasJetpack && Input.GetKeyDown(KeyCode.W))
        {
            hasJetpack = false;
            particleSystem.Play();
            player.IsJetpacking = true;
            timer = Time.time + jetPackDuration;
            audioSource.Play();
        }
        if(player.IsJetpacking && Time.time > timer)
        {
            player.IsJetpacking = false;
        }
    }
}
