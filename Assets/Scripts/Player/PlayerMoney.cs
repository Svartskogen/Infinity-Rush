using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int currentMoney;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(Constants.Money_Pref))
        {
            PlayerPrefs.SetInt(Constants.Money_Pref, 0);
        }
        LoadMoney();
    }
    void SaveMoney()
    {
        PlayerPrefs.SetInt(Constants.Money_Pref, currentMoney);
    }
    void LoadMoney()
    {
        currentMoney = PlayerPrefs.GetInt(Constants.Money_Pref);
    }
    public void GiveMoney(int amount)
    {
        currentMoney += amount;
        SaveMoney();
    }
    public bool SafeBuy(int cost)
    {
        if(currentMoney - cost >= 0)
        {
            currentMoney -= cost;
            SaveMoney();
            return true;
        }
        else
        {
            return false;
        }
    }
}
