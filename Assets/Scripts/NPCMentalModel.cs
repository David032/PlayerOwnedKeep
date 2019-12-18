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
    public float opinion = 0;

    NPCOpinionRenderer opinionRenderer;

    void Start() 
    {
        opinionRenderer = GetComponent<NPCOpinionRenderer>();
    }

    void Update() 
    {
        opinionRenderer.UpdateDisplay(opinion);
    }
}
