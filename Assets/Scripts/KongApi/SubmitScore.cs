using UnityEngine;
using System.Runtime.InteropServices;

public class SubmitScore : MonoBehaviour {

    public const string HIGHSCORE = "Highscore";


    [DllImport("__Internal")]
    private static extern void SubmitKongStat(string StatName, int StatValue);

    //public int LevelsBeat = 1;


    // use this to submit
    //Change YOURSTATNAME, to the statistic you wish to use, and LevelsBeat to the value

    public static void SubmitHighScore(int score)
    {
        SubmitKongStat(HIGHSCORE, score);
    }
    //SubmitKongStat("YOURSTATNAME", LevelsBeat);
}
