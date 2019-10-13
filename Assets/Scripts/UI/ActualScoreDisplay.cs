using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualScoreDisplay : MonoBehaviour
{
    private Text text;
    private Transform player;

    private int maxAltura;
    // Start is called before the first frame update
    void Start()
    {
        maxAltura = 0;
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y > maxAltura)
        {
            maxAltura = (int)player.position.y;
        }
        text.text = "Score: " + (HighScoreSet.gameScore + maxAltura);
    }
}
