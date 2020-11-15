using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Buy and UI logic of the Bubble consumable item.
/// </summary>
public class BubbleBuy : MonoBehaviour
{
    public PlayerMoney playerRef;
    public PlayerHealth playerHealth;
    public int cost;

    Text costText;
    Button button;

    void Start()
    {
        costText = GetComponentInChildren<Text>();
        button = GetComponent<Button>();
        costText.text = cost.ToString();
    }
    void Update()
    {
        if(playerRef.currentMoney > cost || !playerHealth.HasShield)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
    public void BuyShield()
    {
        if (playerRef.SafeBuy(cost))
        {
            playerHealth.HasShield = true;
        }
    }
}
