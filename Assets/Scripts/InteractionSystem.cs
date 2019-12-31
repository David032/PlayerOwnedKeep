using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public const float MEMORYDECAY = 1000f;
    // Start is called before the first frame update

    public float calculateTrust(NPCMentalModel npcA, NPCMentalModel npcB, float moodA) 
    {
        int commonLikes = 0;
        int commonDislikes = 0;
        int elementsA = npcA.likes.Capacity + npcA.dislikes.Capacity;
        int elementsB = npcB.likes.Capacity + npcB.dislikes.Capacity;
        float mood = moodA;
        float minimumTrust = GameObject.FindGameObjectWithTag("GameController").GetComponent<InteractionSystemController>().minimumTrustLevel;
        //print("There are " + elementsA + " categories in NPC A(And their mood is at " +mood+", " +
        //    "and " + elementsB + " categories in NPC B. The minimum trust level is currently at: " + minimumTrust);


        npcA.likes.Sort();
        npcA.dislikes.Sort();
        npcB.likes.Sort();
        npcB.dislikes.Sort();
        //print("NPC categories sorted");

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

        float decayTime = 1 - (currentTime - eventMemory.learntTime) / MEMORYDECAY;

        return decayTime;
    }

    public float calculateValue(NPCMentalModel npc, Event eventId) 
    {
        float fValue;

        if (npc.eventMemories.Capacity == 0)
        {
            fValue = -1;
            return fValue;
        }

        NPCEventMemory thisEventKnowledge;
        foreach (NPCEventMemory item in npc.eventMemories)
        {
            if (item.learntEvent == eventId)
            {
                thisEventKnowledge = item;
                fValue = calculateDecay(thisEventKnowledge) * (calculateCommonalities(npc, eventId)) * eventId.weight;
                item.fValue = fValue;
                return fValue;
            }
        }

        fValue = -1;
        return fValue;
    }

    public float calculateOpinion(NPCMentalModel npc) 
    {
        float opinion = 0;
        float sumOfValueFunctions = 0;

        foreach (NPCEventMemory item in npc.eventMemories)
        {
            sumOfValueFunctions += item.fValue;
        }
        opinion = Mathf.InverseLerp(-100, 100, sumOfValueFunctions);
        return opinion;
    }

    public void shareEvent(NPCMentalModel npcA, NPCMentalModel npcB, float mood) 
    {
        float trustVal = calculateTrust(npcA, npcB, mood);
        print("The trust value between " + npcA.gameObject.name + " and " + npcB.gameObject.name + " is " + trustVal);
        float commChance = Random.Range(0f, 1f);
        print("The communication chance is " + commChance);

        if (trustVal > commChance)
        {
            print("Communication established!");
            npcA.events.Sort();
            npcB.events.Sort();

            Event eventToShare = npcA.events[Random.Range(0, npcA.events.Capacity)];

            if (!npcB.events.Contains(eventToShare))
            {
                npcB.events.Add(eventToShare);
                npcB.eventMemories.Add(new NPCEventMemory(eventToShare));
            }      
        }
        else
        {
            print("Communication failed!");
        }
    }
}
