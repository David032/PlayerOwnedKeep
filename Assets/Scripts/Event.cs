using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public string EventId;
    public List<categories> Categories;
    public float weight;
    public bool memorable;

    public NPCEventMemory EventMemory;

    void Start()
    {
        //this.name = EventId;
    }

    public Event() 
    { }

    public Event(string eventDesc, List<categories> eventCategories, float eventWeight, bool unforgetable) 
    {
        EventId = eventDesc;
        Categories = eventCategories;
        weight = eventWeight;
        memorable = unforgetable;
    }

    ~Event() 
    { }

    public void CreateEvent(string eventDesc, List<categories> eventCategories, float eventWeight, bool unforgetable)
    {
        EventId = eventDesc;
        Categories = eventCategories;
        weight = eventWeight;
        memorable = unforgetable;
    }
}
