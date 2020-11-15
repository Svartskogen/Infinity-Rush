using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds the <see cref="PlayerKill"/> event and triggers it when the player falls.
/// </summary>
public class PlayerKillLimit : MonoBehaviour
{
    public class PlayerKillArgs : EventArgs
    {

    }
    public static event EventHandler<EventArgs> PlayerKill;

    public static bool triggerEvent;
    
    void Start()
    {
        triggerEvent = false;
    }

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
    public static void TriggerEventStatic()
    {
        triggerEvent = true;
    }
}
