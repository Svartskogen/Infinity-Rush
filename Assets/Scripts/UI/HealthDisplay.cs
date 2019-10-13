using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;

    private PlayerHealth playerHealth;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        corazon1.SetActive(false);
        corazon2.SetActive(false);
        corazon3.SetActive(false);
        health = playerHealth.GetHealth();
        if(health >= 1)
        {
            corazon1.SetActive(true);
        }
        if(health >= 2)
        {
            corazon2.SetActive(true);
        }
        if(health >= 3)
        {
            corazon3.SetActive(true);
        }
    }
}
