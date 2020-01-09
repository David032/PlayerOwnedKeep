using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCperspective : Sense
{
    public int fieldOfView = 25;
    public int viewDistance = 25;
    private Transform playerTransform;

    protected override void Initialize()
    {
        playerTransform =
        GameObject.FindGameObjectWithTag("Player").transform;
    }
    protected override void UpdateSense()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= detectionRate)
        {
            Detect();
        }
    }

    void Detect()
    {
        RaycastHit hit;
        Vector3 frontRayPoint = transform.position + (transform.forward * viewDistance);

        if (Physics.Raycast(transform.position, frontRayPoint, out hit, viewDistance))
        {
            if (hit.collider.GetComponent<EventObject>())
            {
                Debug.DrawLine(transform.position, hit.transform.position);
                if (hit.collider.GetComponent<EventObject>().EventObjectType == ObjectType.Visual)
                {
                    if (!MentalModel.events.Contains(hit.collider.GetComponent<EventObject>().LinkedEvent))
                    {
                        Event eventBeingAdded = hit.collider.GetComponent<EventObject>().LinkedEvent;
                        MentalModel.events.Add(eventBeingAdded);

                        MentalModel.eventMemories.Add(new NPCEventMemory(hit.collider.GetComponent<EventObject>().LinkedEvent));
                    }
                }
                else
                {
                    print("That's not a visual event!");
                }
            }
            else
            {
                //print("That's not an event @" + gameObject.name);
            }
        }
    }

    void OnDrawGizmos()
    {
        Vector3 frontRayPoint = transform.position + (transform.forward *
        viewDistance);
        Debug.DrawLine(transform.position, frontRayPoint, Color.green);
    }
}