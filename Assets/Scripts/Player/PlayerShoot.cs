﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the player's shooting towards the <see cref="point"/> which is updated by a <see cref="WeaponLookAtMouse"/> script.
/// </summary>
public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform point;
    public GameObject bulletPrefab;
    private ParticleSystem particleSystem;
    private AudioSource audioSource;
    WeaponFx weaponFx;

    public WeaponsUnlocks.Weapon weapon = WeaponsUnlocks.Weapon.Pistol;

    private float cooldown;
    void Awake()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        weaponFx = GetComponent<WeaponFx>();
        weaponFx.SetVisualsTo(weapon);
    }

    void Update()
    {
        if (GameManager.Playing() && Input.GetKeyDown(KeyCode.Mouse0) && Time.time > cooldown)
        {
            cooldown = Time.time + 0.3f;
            particleSystem.Play();
            audioSource.Play();
            Shoot();
        }
    }
    void Shoot()
    {
        switch (weapon)
        {
            case WeaponsUnlocks.Weapon.Pistol:
            {
                Instantiate(bulletPrefab, point.transform.position, point.transform.rotation);
                break;
            }
            case WeaponsUnlocks.Weapon.Shotgun:
            {
                Instantiate(bulletPrefab, point.transform.position, point.transform.rotation);
                Instantiate(bulletPrefab, point.transform.position + new Vector3(0.5f,0.5f,0.5f), point.transform.rotation);
                Instantiate(bulletPrefab, point.transform.position - new Vector3(0.5f,0.5f,0.5f), point.transform.rotation);                
                break;
            }
            case WeaponsUnlocks.Weapon.BurstRifle:
            {
                Instantiate(bulletPrefab, point.transform.position, point.transform.rotation);
                StartCoroutine(DelayedShot(0.2f));
                StartCoroutine(DelayedShot(0.4f));
                break;
            }
            case WeaponsUnlocks.Weapon.RocketLauncher:
            {
                Debug.LogError("Rocket Launcher not defined");
                return;
            }
        }
        
    }
    IEnumerator DelayedShot(float timer)
    {
        yield return new WaitForSeconds(timer);
        Instantiate(bulletPrefab, point.transform.position, point.transform.rotation);
        audioSource.Play();
    }
    public void SetWeaponTo(WeaponsUnlocks.Weapon weapon)
    {
        this.weapon = weapon;
        weaponFx.SetVisualsTo(weapon);
    }
    
}
