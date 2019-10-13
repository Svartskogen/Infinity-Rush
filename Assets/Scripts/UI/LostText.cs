using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
public class LostText : MonoBehaviour
{
    public Color desiredColor;
    bool toggle;
    private Text text;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 2f;
        text = GetComponent<Text>();
        toggle = false;
        PlayerKillLimit.PlayerKill += PlayerKillLimit_PlayerKill;
    }

    private void PlayerKillLimit_PlayerKill(object sender, System.EventArgs e)
    {
        toggle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle)
        {
            text.color = Color.Lerp(text.color, desiredColor,time * Time.deltaTime);
        }
    }
}
