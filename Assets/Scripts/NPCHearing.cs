using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class NPCHearing : Sense
{
    SphereCollider hearingRange;

    bool amInteracting = false;
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
            if (other.gameObject.tag == "NPC")
            {
                print("It's a friend?");
                print(GetComponent<InteractionSystem>().calculateTrust(GetComponent<NPCMentalModel>(), other.gameObject.GetComponent<NPCMentalModel>(), 1));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            print("Reset Interaction");
            amInteracting = false;
        }
    }
}


