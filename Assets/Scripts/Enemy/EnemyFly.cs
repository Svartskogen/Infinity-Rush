using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script responsible of the Enemy movement.
/// </summary>
public class EnemyFly : MonoBehaviour
{
    [SerializeField] float speed;

    private Transform player;
    private float cooldown;
    private bool moveOrder; //Should the enemy move?
    private bool fast;
    private Vector3 moveTo;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moveOrder = false;
        fast = false;
    }

    void Update()
    {
        if(Time.time > cooldown)
        {
            cooldown = Time.time + 1;
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer > 5)
            {
                //If the player went far enough, move faster to keep up with his pace.
                if(distanceToPlayer > 15)
                {
                    Vector3 pos = player.transform.position;
                    pos.y += 6;
                    fast = true;
                    MoveTo(pos);
                }
                else
                {
                    Vector3 pos = player.transform.position;
                    pos.y += 6;
                    fast = false;
                    MoveTo(pos);
                }
            }
        }
        //The enemy must move, handle each step.
        if (moveOrder)
        {
            float step = speed * Time.deltaTime;
            if (fast)
            {
                step *= 3;
            }
            transform.position = Vector2.MoveTowards(transform.position, moveTo, step);
        }
        //If the enemy did reach his destination, stop.
        if(Vector3.Distance(transform.position,moveTo) < 1)
        {
            moveOrder = false;
        }
    }
    void MoveTo(Vector3 position)
    {
        moveTo = position;
        moveOrder = true;
    }
    /// <summary>
    /// Returns true if the player is close enough to shoot, used by <see cref="EnemyShoot"/>
    /// </summary>
    public bool IsClose()
    {
        return (Vector3.Distance(transform.position, player.position) < 6);
    }
}
