using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Reloads the scene after a brief delay on <see cref="PlayerKillLimit.PlayerKill"/> event
/// </summary>
public class ReloadScene : MonoBehaviour
{
    private bool enabled;
    private bool firecd;
    private float cd;

    void Start()
    {
        enabled = false;
        firecd = false;
        PlayerKillLimit.PlayerKill += PlayerKillLimit_PlayerKill;
    }
    private void PlayerKillLimit_PlayerKill(object sender, System.EventArgs e)
    {
        cd = Time.time + 1f;
        firecd = true;
    }
    void Update()
    {
        if (firecd && Time.time > cd && Input.anyKey)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
