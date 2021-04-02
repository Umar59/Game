using System;
using UnityEngine;

public class M4 : MonoBehaviour, Gun
{
    public Transform rHand;
    public Transform lHand;
    
    public float rateFire;
    private float nextFire;
    private AudioSource shootSound;
    public AudioClip fire;
    public ParticleSystem muzzleFlash;
    public Transform bulletSpawn;
    public Transform forRay;

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

            Ray ray = new Ray(forRay.transform.position, forRay.transform.forward);

            Debug.DrawRay(forRay.transform.position, forRay.transform.forward * 10f, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag.Equals("Enemy"))
                {
                    hit.collider.gameObject.GetComponent<EnemyController>().TakeDamage(20);
                }
            }
        }
        
    }

    public void SetPosHand()
    {
        rHand.localPosition = new Vector3(0.003000238f, -0.120003f, 0.164999f);
        rHand.localRotation = Quaternion.Euler(75.902f, -80.729f, 8.241f);

        lHand.localPosition = new Vector3(-0.05900006f, -0.07099941f, 0.427f);
        lHand.localRotation = Quaternion.Euler(5.975f, -19.025f, -162.685f);
    }

    public void SetDefault()
    {
        
    }
}
