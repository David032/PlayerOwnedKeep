using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class NPCHearing : Sense
{
    SphereCollider hearingRange;

    public bool amInteracting = false;
    protected override void Initialize()
    {
        hearingRange = GetComponent<SphereCollider>();
    }
    protected override void UpdateSense()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (!amInteracting)
        {
            print("Not currently interacting");
            if (other.gameObject.tag == "NPC")
            {
                print("It's an NPC");
                if (other.gameObject.GetComponent<NPCMentalModel>().events.Capacity != 0)
                {
                    print("Their memory isn't 0");
                    amInteracting = true;
                    GetComponent<InteractionSystem>().shareEvent(MentalModel, other.GetComponent<NPCMentalModel>(), MentalModel.mood);                 
                    amInteracting = false;
                }

            }
        }
    }


}


