using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Small variation of the <see cref="LookAtTransform"/> script, which aims towards the mouse position and flips the sprite given the case.
/// </summary>
public class WeaponLookAtMouse : MonoBehaviour
{
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(transform.rotation.eulerAngles.z > 0 && transform.rotation.eulerAngles.z < 180)
        {
            sprite.flipY = true;
        }
        else
        {
            sprite.flipY = false;
        }
    }
}
