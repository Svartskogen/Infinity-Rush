using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleBuy : MonoBehaviour
{
    public PlayerMoney playerRef;
    public PlayerHealth playerHealth;
    public int cost;

    Text costText;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        costText = GetComponentInChildren<Text>();
        button = GetComponent<Button>();
        costText.text = cost.ToString();
    }

    // Update is called once per frame
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
