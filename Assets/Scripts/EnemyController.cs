using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour, IDamageable<int>
{
    [SerializeField] public int health;
    private Animator _animator;
    private NavMeshAgent _agent;
    public ParticleSystem bloodParticle;
    public Slider slider;
    public GameObject minimapIcon;

    public GameObject targetHero;
    private bool _attackState;
    public int damage = 1;
    public float ratePunch = 1f;
    private float nextPunch;
    IDamageable<int> player_damage;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        targetHero = GameObject.FindGameObjectWithTag("Player");
        slider.maxValue = health;
        slider.value = health;
        player_damage = targetHero.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        SetAnimation();
        
        if (health > 0)
            _agent.SetDestination(targetHero.transform.position);
        else
            _agent.enabled = false;   // отключаю аггента, чтобы  после смерти он за ним не бежал


        if (CheckDistance())
        {
            Attack();
            if (Time.time > nextPunch)
            {
               nextPunch = Time.time + 1f / ratePunch;
               player_damage.TakeDamage(damage);

            }
            
        }
    }



    private void SetAnimation()
    {
        if (_agent.velocity != Vector3.zero)
        {
            _animator.SetBool("velocity", true);
        }
        else
        {
            _animator.SetBool("velocity", false);
           
        }
    }

    private IEnumerator Death(GameObject zombie)
    {
        yield return new WaitForSeconds(7f);           // Удаление объекта со сцены
        Destroy(zombie);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            _attackState = true;
            Debug.Log("trig");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            _attackState = false;
        }
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }

    private bool CheckDistance()
    {
        return 1f > Vector3.Distance(transform.position, targetHero.transform.position);
    }

    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            slider.value = health;
            bloodParticle.Play();
        }
        if (health <= 0)
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;    // отключаю коллайдер, чтобы он больше в него не стрелял
            gameObject.GetComponent<BoxCollider>().enabled = false;
            _animator.SetTrigger("Death");
            Destroy(minimapIcon);
            StartCoroutine(Death(gameObject));
        }
    }
}
            
        




