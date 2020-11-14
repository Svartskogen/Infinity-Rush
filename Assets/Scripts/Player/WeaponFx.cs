using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the different weapon's sprites and audio clips based on the <see cref="WeaponsUnlocks.Weapon"/> enum.
/// </summary>
public class WeaponFx : MonoBehaviour
{
    public Sprite[] weaponSprites = new Sprite[WeaponsUnlocks.WeaponsAmount];
    public AudioClip[] audioClips = new AudioClip[WeaponsUnlocks.WeaponsAmount];

    AudioSource audioSource;
    SpriteRenderer spriteRenderer;

    void Awake()
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
