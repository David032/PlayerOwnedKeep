using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCOpinionRenderer))]
public class NPCMentalModel : MonoBehaviour
{
    public List<categories> likes;
    public List<categories> dislikes;
    public List<Event> events;
    public List<Event> unforgettableEvents;
    public List<NPCEventMemory> eventMemories;
    public float opinion = 0;

    [Range(0,1)]
    public float mood = 1;

    NPCOpinionRenderer opinionRenderer;
    InteractionSystem interactionSystem;

    void Start() 
    {
        opinionRenderer = GetComponent<NPCOpinionRenderer>();
        interactionSystem = GetComponent<InteractionSystem>();
    }

    void Update() 
    {
        opinionRenderer.UpdateDisplay(opinion);

        foreach (Event item in events)
        {
            float testInteractionValue = interactionSystem.calculateValue(this, item);
        }

        opinion = interactionSystem.calculateOpinion(this);
    }
}
