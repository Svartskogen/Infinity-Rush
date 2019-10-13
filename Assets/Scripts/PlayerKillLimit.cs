using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillLimit : MonoBehaviour
{
    public class PlayerKillArgs : EventArgs
    {

    }
    public static event EventHandler<EventArgs> PlayerKill;

    public static bool triggerEvent;
    // Start is called before the first frame update
    void Start()
    {
        triggerEvent = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerEvent)
        {
            triggerEvent = false;
            PlayerKill?.Invoke(this, EventArgs.Empty);
        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerKill?.Invoke(this, EventArgs.Empty);
        }
    }

    public static void triggerEventStatic()
    {
        triggerEvent = true;
    }
}
