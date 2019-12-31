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
        //print("These NPCs have " + commonLikes + " common likes, and " + commonDislikes + " common dislikes.");

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
        print("Commonalities value: " + commonalities);
        return commonalities;
    }

    public float calculateDecay(NPCEventMemory eventMemory) 
    {
        float currentTime = GameObject.FindGameObjectWithTag("GameController").GetComponent<TimeManager>().getRawTime();

        float decayTime = 1 - (currentTime - eventMemory.learntTime) / MEMORYDECAY;

        print("Decay time: " + decayTime);
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
                return fValue;
            }
        }

        fValue = -1;
        return fValue;
    }
}
