using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to set highscores to the local save system, also tries to update it to the Kongregate's servers
/// </summary>
public class HighScoreSet : MonoBehaviour
{
    public static int gameScore;

    void Start()
    {
        gameScore = 0;
        if (!PlayerPrefs.HasKey(Constants.HighScore_Pref))
        {
            PlayerPrefs.SetInt(Constants.HighScore_Pref, 0);
        }
    }
    public static void SetHighscore(int score)
    {
        int actual = PlayerPrefs.GetInt(Constants.HighScore_Pref);
        if(score > actual)
        {
            PlayerPrefs.SetInt(Constants.HighScore_Pref, score);
        }
        try
        {
            SubmitScore.SubmitHighScore(score);
        }
        catch
        {
            Debug.LogWarning("No conectado a kongregate");
        }
    }
}
