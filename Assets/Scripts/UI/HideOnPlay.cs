using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used to set current <see cref="GameObject"/> to inactive on gameplay.
/// </summary>
public class HideOnPlay : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Playing())
        {
            gameObject.SetActive(false);
        }
    }
}
