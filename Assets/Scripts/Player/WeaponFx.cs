using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFx : MonoBehaviour
{
    public Sprite[] weaponSprites = new Sprite[WeaponsUnlocks.WeaponsAmount];
    public AudioClip[] audioClips = new AudioClip[WeaponsUnlocks.WeaponsAmount];

    AudioSource audioSource;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetVisualsTo(WeaponsUnlocks.Weapon weapon)
    {
        audioSource.clip = audioClips[(int)weapon];
        spriteRenderer.sprite = weaponSprites[(int)weapon];
    }
}
