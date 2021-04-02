using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Character character;
    public int currentWeapon = 0;

    public void Start()
    {
        SetVeapon();
    }
    

    public void SetVeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            Gun gun = weapon.gameObject.GetComponent<Gun>();
            
            if (i == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
                gun.SetPosHand();
                
                character.gun = gun;
            }
            else
            {
                gun.SetDefault();
                weapon.gameObject.SetActive(false);
            }

            i++;
        }
    }

    public void RefreshCurrentWeapon()
    {
        if (currentWeapon == 2)
        {
            currentWeapon = 0;
        }
        else
        {
            currentWeapon++;
        }
        
        SetVeapon();
    }
}
