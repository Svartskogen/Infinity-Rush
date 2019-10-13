using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    public float speed;

    private Transform player;

    private float cooldown;
    private bool moveOrder;
    private bool fast;
    private Vector3 moveTo;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moveOrder = false;
        fast = false;
    }

    // Update is called once per frame
    void Update()
    {


        if(Time.time > cooldown)
        {
            cooldown = Time.time + 1;
            if(Vector3.Distance(transform.position,player.position) > 5)
            {
                if(Vector3.Distance(transform.position, player.position) > 15)
                {
                    //Debug.Log("El jugador esta lejos, acercandose rapido");
                    Vector3 pos = player.transform.position;
                    fast = true;
                    pos.y += 6;
                    MoveTo(pos);
                }
                else
                {
                    //Debug.Log("El jugador esta cerca, acercandose");
                    Vector3 pos = player.transform.position;
                    pos.y += 6;
                    fast = false;
                    MoveTo(pos);
                }
            }
        }

        if (moveOrder)
        {
            float step = speed * Time.deltaTime;
            if (fast)
            {
                step *= 3;
            }
            transform.position = Vector2.MoveTowards(transform.position, moveTo, step);
        }
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
    public bool isClose()
    {
        return (Vector3.Distance(transform.position, player.position) < 6);
    }
}
