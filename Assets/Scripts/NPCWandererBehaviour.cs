using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCWandererBehaviour : MonoBehaviour
{
    public int NavmeshMask;

    float MinX;
    float MaxX;
    float MinZ;
    float MaxZ;
    NavMeshHit navmeshHit;
    NavMeshAgent agent;

    bool tryingToFindDestination = false;
    bool foundDestionation = false;


    // Start is called before the first frame update
    void Start()
    {
        DefineBoundries();
    }

    // Update is called once per frame
    void Update()
    {
        if (!tryingToFindDestination)
        {
            tryingToFindDestination = true;
            while (!foundDestionation)
            {
                Vector3 destination = GenerateWanderingPoint();
                int tries = 0;
                if (NavMesh.SamplePosition(destination,out navmeshHit,1,NavMesh.AllAreas))
                {
                    if (navmeshHit.mask == NavmeshMask)
                    {
                        agent.SetDestination(destination);
                        print("Successfuly set the destination of " + gameObject.name + " to " + destination + ". It took " + tries + " tries");
                    }
                    else 
                    {
                        tries += 1;
                        print("Failed to set destination correctly, it has taken " + gameObject.name + " " + tries);
                    }
                }
            }

        }
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();


    }

    Vector3 GenerateWanderingPoint() 
    {
        Vector3 randomDestination;

        return randomDestination = new Vector3(Random.Range(MinX, MaxX), 1, Random.Range(MinZ, MaxZ));
    }

    void DefineBoundries()
    {
        MinX = GameObject.FindGameObjectWithTag("GameController").GetComponent<NavigationController>().levelMesh.sourceBounds.min.x;// * 0.6f;
        MaxX = GameObject.FindGameObjectWithTag("GameController").GetComponent<NavigationController>().levelMesh.sourceBounds.max.x;// * 0.6f;
        MinZ = GameObject.FindGameObjectWithTag("GameController").GetComponent<NavigationController>().levelMesh.sourceBounds.min.z;// * 0.6f;
        MaxZ = GameObject.FindGameObjectWithTag("GameController").GetComponent<NavigationController>().levelMesh.sourceBounds.max.z;// * 0.6f;
    }
}
