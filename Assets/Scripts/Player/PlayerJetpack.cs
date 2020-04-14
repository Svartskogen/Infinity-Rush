using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJetpack : MonoBehaviour
{
    public bool hasJetpack = false;
    public float jetPackDuration;
    public float jetPackThrust;

    Player player;
    SpriteRenderer jetpackVisual;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        jetpackVisual = GetComponent<SpriteRenderer>();
        player = GetComponentInParent<Player>();
        player.SetJetpackThrust(jetPackThrust);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasJetpack)
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
            player.IsJetpacking = true;
            timer = Time.time + jetPackDuration;
        }
        if(player.IsJetpacking && Time.time > timer)
        {
            player.IsJetpacking = false;
        }
    }
}
