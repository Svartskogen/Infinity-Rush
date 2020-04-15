using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreSet : MonoBehaviour
{
    public static int gameScore;
    // Start is called before the first frame update
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

            //throw;
        }
    }
}
