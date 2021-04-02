using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSwapGun : MonoBehaviour, IPointerDownHandler
{
    public WeaponHolder weaponHolder;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        weaponHolder.RefreshCurrentWeapon();
    }
}
