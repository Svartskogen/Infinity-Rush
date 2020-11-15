using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages all the logic of UI of the Weapons shop.
/// </summary>
public class WeaponBuyBtn : MonoBehaviour
{
    public WeaponsUnlocks.Weapon weapon;

    Button button;
    public Image coinImage;
    Text buttonText;

    WeaponsUnlocks weaponsUnlocks;
    State state;
    int cost;

    void Start()
    {
        weaponsUnlocks = GetComponentInParent<WeaponsUnlocks>();
        CheckStateFromWeaponsUnlocks();
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
    }
    void CheckStateFromWeaponsUnlocks()
    {
        switch (weapon)
        {
            case WeaponsUnlocks.Weapon.Pistol:
            {
                state = State.Unlocked;
                cost = 0;
                break;
            }
            case WeaponsUnlocks.Weapon.Shotgun:
            {
                cost = weaponsUnlocks.shotgun_cost;
                if (weaponsUnlocks.shotgun_unlocked)
                {
                    state = State.Unlocked;
                }
                else
                {
                    state = State.Buyable;
                }
                break;
            }
            case WeaponsUnlocks.Weapon.BurstRifle:
            {
                cost = weaponsUnlocks.rifle_cost;
                if (weaponsUnlocks.rifle_unlocked)
                {
                    state = State.Unlocked;
                }
                else
                {
                    state = State.Buyable;
                }
                break;
            }
        }
    }
    void Update()
    {
        CheckStateFromWeaponsUnlocks();
        if(state == State.Buyable)
        {
            coinImage.enabled = true;
            buttonText.text = cost.ToString();
        }
        else
        {
            coinImage.enabled = false;
            buttonText.text = "Equip";
        }
    }
    public void UseButton()
    {
        if(state == State.Buyable)
        {
            weaponsUnlocks.BuyWeapon(weapon);
            CheckStateFromWeaponsUnlocks();
        }
        else
        {
            weaponsUnlocks.SetPlayerWeapon(weapon);
        }
    }
    public enum State { Unlocked, Buyable};
}
