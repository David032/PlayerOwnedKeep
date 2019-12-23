using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public List<Event> Events;


    // Start is called before the first frame update
    void Start()
    {
        //List<categories> testCategories = new List<categories>();
        //testCategories.AddRange(new categories[] { categories.Good,categories.Dog});
        //Event TestEvent = this.gameObject.AddComponent<Event>();
        //TestEvent.CreateEvent("Test Event", testCategories, 0.75f, true);
        //Events.Add(TestEvent);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Event item in gameObject.GetComponents<Event>())
        {
            if (!Events.Contains(item))
            {
                Events.Add(item);
                item.name = item.EventId;
            }
        }
    }
}
