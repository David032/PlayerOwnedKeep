using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public List<Event> Events;

    // Start is called before the first frame update
    void Start()
    {

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
