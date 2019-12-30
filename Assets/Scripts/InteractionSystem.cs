using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float calculateTrust(NPCMentalModel npcA, NPCMentalModel npcB, float moodA) 
    {
        float trustVal = 0;
        int commonLikes = 0;
        int commonDislikes = 0;
        int elementsA = npcA.likes.Capacity + npcA.dislikes.Capacity;
        int elementsB = npcB.likes.Capacity + npcB.dislikes.Capacity;
        float mood = moodA;
        float minimumTrust = GameObject.FindGameObjectWithTag("GameController").GetComponent<InteractionSystemController>().minimumTrustLevel;
        print("There are " + elementsA + " categories in NPC A(And their mood is at " +mood+", " +
            "and " + elementsB + " categories in NPC B. The minimum trust level is currently at: " + minimumTrust);


        npcA.likes.Sort();
        npcA.dislikes.Sort();
        npcB.likes.Sort();
        npcB.dislikes.Sort();
        print("NPC categories sorted");

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
        print("These NPCs have " + commonLikes + " common likes, and " + commonDislikes + " common dislikes.");

        int commonalities = commonLikes + commonDislikes;
        int elements = elementsA + elementsB;

        trustVal = mood * ((commonalities / elements) + minimumTrust);
        return trustVal;
    }
}
