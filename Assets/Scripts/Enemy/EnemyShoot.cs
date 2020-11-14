using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script responsible of spawning <see cref="bulletPrefab"/> at the given <see cref="instantiationPoint"/>
/// </summary>
public class EnemyShoot : MonoBehaviour
{
    /// <summary>
    /// Point that aims towards the player, used with a <see cref="LookAtTransform"/> script
    /// </summary>
    public Transform instantiationPoint;
    public GameObject bulletPrefab;

    private float cooldown;
    private AudioSource audio;
    private EnemyFly fly;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        fly = GetComponent<EnemyFly>();
    }
    void Update()
    {
        if(Time.time > cooldown && fly.IsClose())
        {
            cooldown = Time.time + 3f;
            Shoot();
            audio.pitch = Random.Range(0.8f, 1.2f);
            audio.Play();
        }   
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, instantiationPoint.transform.position, instantiationPoint.transform.rotation);
    }
}
