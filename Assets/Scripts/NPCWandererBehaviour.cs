using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCWandererBehaviour : MonoBehaviour
{
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print("I am " + gameObject.name + " and my current area mask is " + agent.areaMask);
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
