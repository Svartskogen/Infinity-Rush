using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    AudioSource audioSource;
    SpriteRenderer spriteRenderer;
    bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        active = true;
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(active && collision.tag == "Player")
        {
            active = false;
            this.enabled = false;
            Destroy(gameObject,1);
            spriteRenderer.enabled = false;
            collision.GetComponent<PlayerMoney>().GiveMoney(1);
            audioSource.Play();
        }
    }
}
