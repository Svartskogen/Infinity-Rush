using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Updates the current <see cref="GameObject"/>'s <see cref="Text"/> with the <see cref="PlayerMoney.currentMoney"/> value
/// </summary>
public class UIMoney : MonoBehaviour
{
    public PlayerMoney playerMoney;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        text.text = playerMoney.currentMoney.ToString();
    }
}
