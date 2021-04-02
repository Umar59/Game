using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class animate : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        if (agent.velocity != Vector3.zero)
        {
            anim.SetBool("velocity", true);

        }
        else   anim.SetBool("velocity", false);

    }
}
