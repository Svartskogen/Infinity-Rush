using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Sets the current <see cref="Text"/> to the current saved highscore
/// </summary>
public class HighScoreText : MonoBehaviour
{
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Highscore: " + PlayerPrefs.GetInt(Constants.HighScore_Pref).ToString();
    }
}
