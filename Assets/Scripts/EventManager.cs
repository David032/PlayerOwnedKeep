using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public List<Event> Events;

    List<categories> testCategories = new List<categories>();
    // Start is called before the first frame update
    void Start()
    {
        testCategories.Add(categories.Good);
        testCategories.Add(categories.Dog);
        Event TestEvent = this.gameObject.AddComponent<Event>();
        TestEvent.CreateEvent("Test Event", testCategories, 0.75f, true);
        Events.Add(TestEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
