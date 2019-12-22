using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        anim.SetInteger("WeaponType_int", 0);
        anim.SetInteger("MeleeType_int", 0);
        anim.SetInteger("Animation_int", 1);

    }
}
