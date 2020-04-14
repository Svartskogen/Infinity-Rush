using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetpackBuy : MonoBehaviour
{
    public PlayerMoney playerRef;
    public PlayerJetpack playerJetpack;
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
