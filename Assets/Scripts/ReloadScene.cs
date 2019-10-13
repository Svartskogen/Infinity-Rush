using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadScene : MonoBehaviour
{
    private bool enabled;
    private bool firecd;
    private float cd;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (firecd && Time.time > cd && Input.anyKey)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
