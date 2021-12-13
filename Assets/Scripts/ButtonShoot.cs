using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonShoot : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    public Character character;
    public MovementController movementController;

    private bool _shootState;

    private void Update()
    {
        if (_shootState)
            character.gun.Shoot();
        
        character.shootState = _shootState;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _shootState = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _shootState = false;
        movementController.AimAtatus = false;
    }
}
