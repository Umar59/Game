using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Knife : MonoBehaviour, Gun
{
    public Animator animator;

    public GameObject boneKnife;
    public Rig rig;
    public Character character;
    public Knife knife;

    public float rateFire;
    private float nextFire;
    private AudioSource shootSound;
    public AudioClip fire;
    
    
    public void Start()
    {
        shootSound = GetComponent<AudioSource>();
    }
    
    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + 1f / rateFire;
            shootSound.PlayOneShot(fire);
            animator.SetTrigger("Shoot");
            Debug.Log("Piu Piu Piu");
        }
        
    }
    
    public void SetPosHand()
    {
        rig.weight = 0;
        boneKnife.gameObject.SetActive(true);
        
    }

    public void SetDefault()
    {
        rig.weight = 1;
        boneKnife.gameObject.SetActive(false);
    }
}
