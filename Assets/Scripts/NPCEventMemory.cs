using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEventMemory : ScriptableObject
{
    public Event learntEvent;
    public float learntTime;
    public string learntEventName;

    public NPCEventMemory(Event eventToAdd) 
    {
        learntTime = GameObject.FindGameObjectWithTag("GameController").GetComponent<TimeManager>().getRawTime();
        learntEvent = eventToAdd;
        learntEventName = eventToAdd.EventId;
    }
}
