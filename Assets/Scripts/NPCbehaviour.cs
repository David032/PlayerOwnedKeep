﻿using System.Collections;
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

    public Transform[] TravellerPoints;
    int TravellerDestPoint = 0;
    float TravellerTimeAtPlace;
    float DesiredTimeAtPlace = 30f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        switch (NPCBehaviourModel)
        {
            case Behaviour.Traveller:
                TravelToNextPoint();
                break;
            case Behaviour.Trader:
                break;
            case Behaviour.Wanderer:
                gameObject.AddComponent<RandomWalk>(); //Note: This is taken from Unity->NavMeshComponent examples
                break;
            case Behaviour.Guard:
                break;
            case Behaviour.Patroller:
                GotoNextPoint();
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (NPCBehaviourModel)
        {
            case Behaviour.Traveller:
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    TravellerTimeAtPlace += Time.deltaTime;
                    if (TravellerTimeAtPlace > DesiredTimeAtPlace)
                    {
                        TravelToNextPoint();
                    }
                }
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

    void TravelToNextPoint() 
    {
        TravellerTimeAtPlace = 0;
        if (TravellerPoints.Length == 0)
        {
            return;
        }
        agent.destination = TravellerPoints[TravellerDestPoint].position;
        TravellerDestPoint = (TravellerDestPoint + 1) % TravellerPoints.Length;
    }
}
