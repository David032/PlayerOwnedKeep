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
            float testInteractionValue = interactionSystem.calculateValue(this, item);
        }

        opinion = interactionSystem.calculateOpinion(this);
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
}


