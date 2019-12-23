using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType 
{
    Visual,
    Audio
}

public class EventObject : MonoBehaviour
{
    public ObjectType EventObjectType = ObjectType.Audio;
    public Event LinkedEvent;
    public string EventId;

    private void OnValidate()
    {
        EventId = LinkedEvent.EventId;
    }
}
