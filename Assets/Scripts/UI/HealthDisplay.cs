using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hacked away 3 state health display.
/// </summary>
public class HealthDisplay : MonoBehaviour
{
    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;

    private PlayerHealth playerHealth;
    private int health;
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
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
