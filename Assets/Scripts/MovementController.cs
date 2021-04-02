using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementController : MonoBehaviour
{
    public Joystick joystick;
    

    public float speedRotation = 5f;
    public float runSpeed = 20f;
    public float walkSpeed = 10f;
    public float rangeForRun = 350f;
    private float _currentSpeedRotation;
    
    private Rigidbody _rigidbody;
    private Animator _animator;

    private GameObject target;
    private Character _character;
    [HideInInspector]public bool aimAtatus;
    

    private void Start()
    {
        _currentSpeedRotation = speedRotation;
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _character = GetComponent<Character>();
    }

    private void FixedUpdate()
    {
        Move();
        
        if (_character.shootState && aimAtatus)
        {
          LookIfShoot();  
        }
        
        
    }

    private void Move()
    {
        Vector2 direction = joystick.direction;
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);

        Quaternion lookRotation =
            moveDirection != Vector3.zero ? Quaternion.LookRotation(moveDirection) : transform.rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _currentSpeedRotation);
        
        float speed = SetSpeed();
        
        _animator.SetInteger("MoveState", (int)speed);
        
        _rigidbody.AddForce(moveDirection * speed);
    }

    private float SetSpeed()                // устанавливает скорость в зависимости от джойтика
    {
        if (joystick.force == 0)
        {
            return 0;
        }
        if (joystick.force > rangeForRun)
        {
            _currentSpeedRotation = speedRotation;          
           return runSpeed; 
        }
        else
        {
            _currentSpeedRotation = speedRotation / 1.5f;
            return walkSpeed;
        }
    }

    private void LookIfShoot()                  // поворачивается к врагу во время стрельбы
    {
        transform.DOLookAt(target.transform.position, 0.5f);
        transform.LookAt(target.transform);
    }

    private void OnTriggerStay(Collider other)        //чекает врагов в коллайдере и назначает цель стрельбы
    {
        
        if (other.tag.Equals("Enemy"))
        {
             aimAtatus = true;
             
             if (other.gameObject.activeSelf == true)
             {
                 target = other.gameObject;
             }
             
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            aimAtatus = false;
        }
    }
    
    
}
