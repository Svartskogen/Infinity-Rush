using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform instanciationPoint;
    public GameObject bulletPrefab;
    private float cooldown;
    private AudioSource audio;
    private EnemyFly fly;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        fly = GetComponent<EnemyFly>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > cooldown && fly.isClose())
        {
            cooldown = Time.time + 3f;
            Shoot();
            audio.pitch = Random.Range(0.8f, 1.2f);
            audio.Play();
        }   
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, instanciationPoint.transform.position, instanciationPoint.transform.rotation);
    }
}
