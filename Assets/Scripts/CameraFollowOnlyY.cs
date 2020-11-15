using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera follow system. only updates if the <see cref="target"/> position is higher than the current <see cref="Transform.position.y"/> value
/// </summary>
public class CameraFollowOnlyY : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = .3f;

    private Vector3 currentVelocity;
    void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position,newPos,ref currentVelocity,smoothSpeed * Time.deltaTime);
        }
    }
}
