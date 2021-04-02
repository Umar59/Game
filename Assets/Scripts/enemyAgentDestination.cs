using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAgentDestination : MonoBehaviour
{

    public NavMeshAgent agent;
    public GameObject hero;

    // Update is called once per frame
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        agent.SetDestination(hero.transform.position);
    }
}
