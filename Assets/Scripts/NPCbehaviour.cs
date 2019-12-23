using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum Behaviour
{
    Traveller,
    Trader,
    Wanderer,
    Guard,
    Patroller
}

public class NPCbehaviour : MonoBehaviour
{
    public Behaviour NPCBehaviourModel = Behaviour.Guard;
    NavMeshAgent agent;

    public Transform[] PatrollerPoints;
    private int PatrollerDestPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (NPCBehaviourModel == Behaviour.Patroller)
        {
            GotoNextPoint();
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (NPCBehaviourModel)
        {
            case Behaviour.Traveller:
                break;
            case Behaviour.Trader:
                break;
            case Behaviour.Wanderer:
                break;
            case Behaviour.Guard:
                //There's no behaviour here intentionally
                break;
            case Behaviour.Patroller:
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    GotoNextPoint();
                break;
            default:
                break;
        }
    }

    void GotoNextPoint()
    {
        if (PatrollerPoints.Length == 0)
            return;
        agent.destination = PatrollerPoints[PatrollerDestPoint].position;
        PatrollerDestPoint = (PatrollerDestPoint + 1) % PatrollerPoints.Length;
    }
}
