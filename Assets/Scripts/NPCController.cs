using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    Rigidbody rb;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        anim.SetInteger("WeaponType_int", 0);
        anim.SetInteger("MeleeType_int", 0);
        //
    }

    private void Update()
    {
        if (agent.velocity != Vector3.zero)
        {
            anim.SetInteger("Animation_int", 0);
            anim.SetFloat("Speed_f", agent.speed);
        }
        else
        {
            anim.SetFloat("Speed_f", 0);
            anim.SetInteger("Animation_int", 1);
        }
    }
}
