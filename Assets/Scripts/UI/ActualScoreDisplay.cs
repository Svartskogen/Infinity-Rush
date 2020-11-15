using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updates current session max score on the <see cref="GameObject"/>'s <see cref="Text"/> component
/// </summary>
public class ActualScoreDisplay : MonoBehaviour
{
    private Text text;
    private Transform player;

    private int maxAltura;

    void Start()
    {
        maxAltura = 0;
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if(player.position.y > maxAltura)
        {
            maxAltura = (int)player.position.y;
        }
        text.text = "Score: " + (HighScoreSet.gameScore + maxAltura);
    }
}
