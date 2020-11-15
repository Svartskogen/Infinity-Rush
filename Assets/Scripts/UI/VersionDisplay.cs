using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays the curret <see cref="Application.version"/> in the <see cref="GameObject"/>'s <see cref="Text"/>
/// </summary>
public class VersionDisplay : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = Application.version;
    }
}
