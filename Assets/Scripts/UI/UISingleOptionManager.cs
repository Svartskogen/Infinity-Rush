using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISingleOptionManager : MonoBehaviour
{
    public Image[] options;

    private int lastIndexSet;
    // Start is called before the first frame update
    void Start()
    {
        lastIndexSet = 0;
        foreach(Image option in options)
        {
            option.enabled = false;
        }
        options[lastIndexSet].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOption(int index)
    {
        for(int i = 0; i < options.Length; i++)
        {
            if (i == index)
            {
                options[i].enabled = true;
            }
            else
            {
                options[i].enabled = false;
            }
            
        }
    }
    public int GetOption(int index)
    {

        return lastIndexSet;
    }
}
