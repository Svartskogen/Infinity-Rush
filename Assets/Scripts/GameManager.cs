using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool play;
    private void Awake()
    {
        instance = this;
        play = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static bool Playing()
    {
        return instance.play;
    }
    public static void StartGame()
    {
        instance.play = true;
    }
}
