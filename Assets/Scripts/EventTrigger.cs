using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    EventManager Manager;
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            List<categories> testCategories = new List<categories>();
            testCategories.AddRange(new categories[] { categories.Change });
            Event thisEventEntry = Manager.gameObject.AddComponent<Event>();
            thisEventEntry.CreateEvent("Someone new arrived", testCategories, 0.75f, true);
            Manager.Events.Add(thisEventEntry);
            Destroy(this.gameObject.GetComponent<BoxCollider>(), 5f);

            EventObject thisEvent = this.gameObject.AddComponent<EventObject>();
            thisEvent.EventId = "Someone new arrived";
            thisEvent.EventObjectType = ObjectType.Visual;
            thisEvent.LinkedEvent = thisEventEntry;
        }
    }
}
