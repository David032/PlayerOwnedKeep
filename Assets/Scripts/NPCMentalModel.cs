﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCOpinionRenderer))]
public class NPCMentalModel : MonoBehaviour
{
    public bool EnableDebug = false;

    public List<categories> likes;
    public List<categories> dislikes;
    public List<Event> events;
    public List<Event> unforgettableEvents;
    public List<NPCEventMemory> eventMemories;
    public float opinion = 0;
    public List<NPCInteractionMemory> interactedNPCS;

    [Range(0,1)]
    public float mood = 1;

    [Range(0.1f, 1f)]
    public float memoryReliability = 0.95f;

    public Faction FactionId = Faction.None;

    NPCOpinionRenderer opinionRenderer;
    InteractionSystem interactionSystem;

    int defaultLikes = 3;
    int defaultDislikes = 1;
    int currentCategories = 16;

    void Start() 
    {
        opinionRenderer = GetComponent<NPCOpinionRenderer>();
        interactionSystem = GetComponent<InteractionSystem>();
        CreateCategories();
    }

    void Update() 
    {
        opinionRenderer.UpdateDisplay(opinion);

        foreach (Event item in events)
        {
            float testInteractionValue = interactionSystem.CalculateValue(this, item);
        }

        opinion = interactionSystem.CalculateOpinion(this);

        if (interactedNPCS.Capacity > 10)
        {
            interactedNPCS = interactedNPCS.OrderBy(w => w.timeAdded).ToList();
            interactedNPCS.Remove(interactedNPCS[0]);
        }

        DebugViews();
        MemoryDecay();
    } 
    void CreateCategories() 
    {
        if (likes.Capacity == 0)
        {
            for (int i = 0; i < defaultLikes; i++)
            {
                int randomSelection = Random.Range(0, currentCategories);
                likes.Add((categories)randomSelection);
                if (dislikes.Contains((categories)randomSelection))
                {
                    dislikes.Remove((categories)randomSelection);
                    i -= 1;
                }
            }
        }
        if (dislikes.Capacity == 0)
        {
            for (int i = 0; i < defaultDislikes; i++)
            {
                int randomSelection = Random.Range(0, currentCategories);
                dislikes.Add((categories)randomSelection);
                if (likes.Contains((categories)randomSelection))
                {
                    likes.Remove((categories)randomSelection);
                    i -= 1;
                }
            }
        }
    }

    void DebugViews() 
    {
        if (EnableDebug)
        {
            foreach (NPCInteractionMemory item in interactedNPCS)
            {
                Debug.DrawLine(this.gameObject.transform.position, item.interactedWith.gameObject.transform.position, Color.red);
            }

            GameObject[] otherNPCS = GameObject.FindGameObjectsWithTag("NPC");
            foreach (GameObject item in otherNPCS)
            {
                if (item.GetComponent<NPCMentalModel>().FactionId == FactionId)
                {
                    Debug.DrawLine(this.transform.position, item.transform.position, Color.blue);
                }
            }
        }
    }

    void MemoryDecay() 
    {
        foreach (NPCEventMemory item in eventMemories)
        {
            if (item.fValue < 0)
            {
                events.Remove(item.learntEvent);
                eventMemories.Remove(item);
                Destroy(item);
                eventMemories.Sort();
            }
        }
    }
}


