using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Saves, loads, and gets the current player money.
/// </summary>
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
    /// <summary>
    /// Gives the player the given amount of money and saves the value to the save system.
    /// </summary>
    public void GiveMoney(int amount)
    {
        currentMoney += amount;
        SaveMoney();
    }
    /// <summary>
    /// Returns true if the player has enough money to buy something, and deducts the given amount.
    /// If the player doesn't have enough money, returns false and doesn't spend any money.
    /// </summary>
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
