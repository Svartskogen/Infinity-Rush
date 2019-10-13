using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform point;
    public GameObject bulletPrefab;
    private ParticleSystem particleSystem;
    private AudioSource audioSource;

    private float cooldown;
    void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Playing() && Input.GetKeyDown(KeyCode.Mouse0) && Time.time > cooldown)
        {
            cooldown = Time.time + 0.3f;
            Shoot();
            particleSystem.Play();
            audioSource.Play();
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, point.transform.position, point.transform.rotation);
    }
}
