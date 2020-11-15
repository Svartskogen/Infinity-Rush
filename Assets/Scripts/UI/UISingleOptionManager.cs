using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Quick and hacky solution to having a single option displayed at a time from a set of <see cref="Image"/>
/// </summary>
public class UISingleOptionManager : MonoBehaviour
{
    public Image[] options;

    private int lastIndexSet;

    void Start()
    {
        lastIndexSet = 0;
        foreach(Image option in options)
        {
            option.enabled = false;
        }
        options[lastIndexSet].enabled = true;
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
