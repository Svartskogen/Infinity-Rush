using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Buy and UI logic of the consumable item.
/// </summary>
public class JetpackBuy : MonoBehaviour
{
    public PlayerMoney playerRef;
    public PlayerJetpack playerJetpack;
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
        if (playerRef.currentMoney > cost || !playerJetpack.hasJetpack)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
    public void BuyJetpack()
    {
        if (playerRef.SafeBuy(cost))
        {
            playerJetpack.hasJetpack = true;
        }
    }
}
