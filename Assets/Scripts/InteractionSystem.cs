using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    InteractionSystemController controller;
    SpawnableController spawnables;
    TimeManager timekeeper;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<InteractionSystemController>();
        spawnables = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnableController>();
        timekeeper = GameObject.FindGameObjectWithTag("GameController").GetComponent<TimeManager>();
    }

    public float calculateTrust(NPCMentalModel npcA, NPCMentalModel npcB, float moodA) 
    {
        int commonLikes = 0;
        int commonDislikes = 0;
        int elementsA = npcA.likes.Capacity + npcA.dislikes.Capacity;
        int elementsB = npcB.likes.Capacity + npcB.dislikes.Capacity;
        float mood = moodA;
        float minimumTrust = controller.minimumTrustLevel;

        npcA.likes.Sort();
        npcA.dislikes.Sort();
        npcB.likes.Sort();
        npcB.dislikes.Sort();

        foreach (categories item in npcA.likes)
        {
            if (npcB.likes.Contains(item))
            {
                commonLikes += 1;
            }
        }
        foreach (categories item in npcA.dislikes)
        {
            if (npcB.dislikes.Contains(item))
            {
                commonDislikes += 1;
            }
        }

        int commonalities = commonLikes + commonDislikes;
        int elements = elementsA + elementsB;

        float trustVal = mood * (commonalities / elements + minimumTrust);
        return trustVal;
    }

    public int calculateCommonalities(NPCMentalModel npc,Event eventId) 
    {
        int likesInEvent = 0;
        int dislikesInEvent = 0;

        foreach (categories item in npc.likes)
        {
            if (eventId.Categories.Contains(item))
            {
                likesInEvent += 1;
            }
        }
        foreach (categories item in npc.dislikes)
        {
            if (eventId.Categories.Contains(item))
            {
                dislikesInEvent += 1;
            }
        }

        int commonalities = likesInEvent - dislikesInEvent;
        return commonalities;
    }

    public float calculateDecay(NPCEventMemory eventMemory) 
    {
        float currentTime = GameObject.FindGameObjectWithTag("GameController").GetComponent<TimeManager>().getRawTime();

        float decayTime = 1 - (currentTime - eventMemory.learntTime) / controller.MEMORYDECAY;

        return decayTime;
    }

    public float calculateValue(NPCMentalModel npc, Event eventId) 
    {
        float fValue = -1;

        if (npc.eventMemories.Capacity == 0)
        {
            fValue = -2;
            return fValue;
        }

        NPCEventMemory thisEventKnowledge;
        foreach (NPCEventMemory item in npc.eventMemories)
        {
            if (item.learntEvent == eventId)
            {
                thisEventKnowledge = item;
                fValue = calculateDecay(thisEventKnowledge) * (calculateCommonalities(npc, eventId)) * eventId.weight;
                thisEventKnowledge.fValue = fValue;
                return fValue;
            }
        }

        fValue = -3;
        return fValue;
    }

    public float calculateOpinion(NPCMentalModel npc) 
    {
        float sumOfValueFunctions = 0;
        float opinion = 0;

        foreach (NPCEventMemory item in npc.eventMemories)
        {
            sumOfValueFunctions += item.fValue;
        }
        if (sumOfValueFunctions != 0)
        {
            opinion = Mathf.InverseLerp(-100, 100, sumOfValueFunctions);
        }

        return opinion;
    }

    public void shareEvent(NPCMentalModel npcA, NPCMentalModel npcB, float mood) 
    {
        float trustVal = calculateTrust(npcA, npcB, mood);
        float commChance = Random.Range(0f, 1f);

        foreach (NPCInteractionMemory item in npcA.interactedNPCS)
        {
            if (item.interactedWith == npcB)
            {
                trustVal += item.lastTrustValue / 10;
            }
        }

        if (trustVal < commChance)
        {
            Event eventToShare = npcA.events[Random.Range(0, (npcA.events.Capacity))];

            if (!npcB.events.Contains(eventToShare))
            {
                npcB.events.Add(eventToShare);
                npcB.eventMemories.Add(new NPCEventMemory(eventToShare));
                Instantiate(spawnables.NPCSharingIcon,npcB.transform);
            }

            npcA.interactedNPCS.Add(new NPCInteractionMemory(npcB, trustVal, timekeeper.getRawTime()));
            npcB.interactedNPCS.Add(new NPCInteractionMemory(npcA, trustVal, timekeeper.getRawTime()));

        }
        else
        {
        }
    }
}
