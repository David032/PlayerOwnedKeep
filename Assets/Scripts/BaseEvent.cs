using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BaseEvent : MonoBehaviour
{
    protected EventManager Manager;
    protected GameObject player;
    protected GameObject dialogueWindow;
    protected GameObject dialogueSpot;

    public string EventName = "";
    public List<categories> EventCategories;
    public bool IsEventUnforgetabble = false;
    [Range(0f, 1f)]
    public float EventWeight = 0.75f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateEvent() 
    {
        Event thisEventEntry = Manager.gameObject.AddComponent<Event>();
        thisEventEntry.CreateEvent(EventName, EventCategories, EventWeight, IsEventUnforgetabble);
        Manager.Events.Add(thisEventEntry);
        EventObject thisEvent = this.gameObject.AddComponent<EventObject>();
        thisEvent.EventId = EventName;
        thisEvent.EventObjectType = ObjectType.Visual;
        thisEvent.LinkedEvent = thisEventEntry;
    }

    public void AssignElements() 
    {
        Manager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        dialogueSpot = GameObject.FindGameObjectWithTag("dialogueSpot");
        dialogueWindow = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnableController>().dialogueWindow;
    }
}
