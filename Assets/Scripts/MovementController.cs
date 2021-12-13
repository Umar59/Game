using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MovementController : MonoBehaviour
{


    private bool aimStatus;
    private float speedRotation = 5f;
    private float runSpeed = 20f;
    private float walkSpeed = 10f;
    private float rangeForRun = 350f;
    private float _currentSpeedRotation;

    public Joystick joystick;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private GameObject target;
    private Character _character;
    public GameObject character;

    public float WalkSpeed { get => walkSpeed; set => walkSpeed = value; }
    public float SpeedRotation { get => speedRotation; set => speedRotation = value; }
    public float RunSpeed { get => runSpeed; set => runSpeed = value; }
    public float RangeForRun { get => rangeForRun; set => rangeForRun = value; }
    public float CurrentSpeedRotation { get => _currentSpeedRotation; set => _currentSpeedRotation = value; }
    public bool AimAtatus { get => aimStatus; set => aimStatus = value; }

    private void Start()
    {
        CurrentSpeedRotation = SpeedRotation;
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _character = GetComponent<Character>();

    }

    private void FixedUpdate()
    {
        Move();

        if (_character.shootState && AimAtatus)
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

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * CurrentSpeedRotation);

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
        if (joystick.force > RangeForRun)
        {
            CurrentSpeedRotation = SpeedRotation;
            return RunSpeed;
        }
        else
        {
            CurrentSpeedRotation = SpeedRotation / 1.5f;
            return WalkSpeed;
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
            AimAtatus = true;

            if (other.gameObject.activeSelf == true)    target = other.gameObject;         
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Enemy"))  AimAtatus = false;
        
    }
}

