using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotates the current <see cref="GameObject"/> towards the given <see cref="target"/>
/// <para>This is a hardcoded version which always targets the Player</para>
/// </summary>
public class LookAtTransform : MonoBehaviour
{
    private Transform target;
    
    void Start()
    {
        //Hardcoded search for Player.
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        var dir = target.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
