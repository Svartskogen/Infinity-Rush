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
        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void SetHighscore(int score)
    {
        int actual = PlayerPrefs.GetInt("highscore");
        if(score > actual)
        {
            PlayerPrefs.SetInt("highscore", score);
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
