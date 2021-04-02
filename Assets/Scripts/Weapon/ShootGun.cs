using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour, Gun
{
    public Transform rHand;
    public Transform lHand;
    
    
    public float rateFire;
    private float nextFire;
    private AudioSource shootSound;
    public AudioClip fire;
    public ParticleSystem muzzleFlash;
    public Transform bulletSpawn;
    
    
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
            muzzleFlash.Play();
            Debug.Log("Bam Bam Bam");
        }
        
    }

    public void SetPosHand()
    {
        rHand.localPosition = new Vector3(-0.0031f, -0.1466f, 0.1661f);
        rHand.localRotation = Quaternion.Euler(75.902f, -80.729f, 8.241f);

        lHand.localPosition = new Vector3(-0.082f, -0.119f, 0.41f);
        lHand.localRotation = Quaternion.Euler(5.975f, -19.025f, -162.685f);
    }

    public void SetDefault()
    {
        
    }
}
