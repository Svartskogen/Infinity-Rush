﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsUnlocks : MonoBehaviour
{
    public enum Weapon { Pistol, Shotgun, BurstRifle,RocketLauncher };
    public const int WeaponsAmount = 4;

    public bool shotgun_unlocked;
    public bool rifle_unlocked;
    public bool rpg_unlocked;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(Constants.Shotgun_Unlock_Pref))
        {
            PlayerPrefs.SetInt(Constants.Shotgun_Unlock_Pref, 0);
        }

        if (!PlayerPrefs.HasKey(Constants.Rifle_Unlock_Pref))
        {
            PlayerPrefs.SetInt(Constants.Rifle_Unlock_Pref, 0);
        }

        if (!PlayerPrefs.HasKey(Constants.Rpg_Unlock_Pref))
        {
            PlayerPrefs.SetInt(Constants.Rpg_Unlock_Pref, 0);
        }
    }
    private void Start()
    {
        LoadPrefs();
    }
    void LoadPrefs()
    {
        if (PlayerPrefs.GetInt(Constants.Shotgun_Unlock_Pref) == 1)
        {
            shotgun_unlocked = true;
        }
        else
        {
            shotgun_unlocked = false;
        }

        if (PlayerPrefs.GetInt(Constants.Rifle_Unlock_Pref) == 1)
        {
            rifle_unlocked = true;
        }
        else
        {
            rifle_unlocked = false;
        }

        if (PlayerPrefs.GetInt(Constants.Rpg_Unlock_Pref) == 1)
        {
            rpg_unlocked = true;
        }
        else
        {
            rpg_unlocked = false;
        }
    }
    void SavePrefs()
    {
        if (shotgun_unlocked)
        {
            PlayerPrefs.SetInt(Constants.Shotgun_Unlock_Pref, 1);
        }
        else
        {
            PlayerPrefs.SetInt(Constants.Shotgun_Unlock_Pref, 0);
        }

        if (rifle_unlocked)
        {
            PlayerPrefs.SetInt(Constants.Rifle_Unlock_Pref, 1);
        }
        else
        {
            PlayerPrefs.SetInt(Constants.Rifle_Unlock_Pref, 0);
        }

        if (rpg_unlocked)
        {
            PlayerPrefs.SetInt(Constants.Rpg_Unlock_Pref, 1);
        }
        else
        {
            PlayerPrefs.SetInt(Constants.Rpg_Unlock_Pref, 0);
        }
    }
}
