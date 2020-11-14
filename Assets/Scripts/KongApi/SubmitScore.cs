using System;
using UnityEngine;
using System.Runtime.InteropServices;

[Obsolete("Deprecated, not releasing to Kongregate anymore", false)]
public class SubmitScore : MonoBehaviour {

    public const string HIGHSCORE = "Highscore";

    [DllImport("__Internal")]
    private static extern void SubmitKongStat(string StatName, int StatValue);

    public static void SubmitHighScore(int score)
    {
        SubmitKongStat(HIGHSCORE, score);
    }
}
