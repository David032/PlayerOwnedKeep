using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCperspective : Sense
{
    public int fieldOfView = 25;
    public int viewDistance = 25;
    private Transform playerTransform;
    private Vector3 rayDirection;

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
        rayDirection = playerTransform.position - transform.position;
        Vector3 frontRayPoint = transform.position + (transform.forward * viewDistance);
        if ((Vector3.Angle(frontRayPoint, transform.forward)) < fieldOfView)
        {
            // Detect if player is within the field of view
            if (Physics.Raycast(transform.position, frontRayPoint, out hit, viewDistance))
            {
                if (hit.collider.GetComponent<EventObject>().EventObjectType == ObjectType.Visual)
                {
                    print("Saw an event");
                    MentalModel.events.Add(hit.collider.GetComponent<EventObject>().LinkedEvent);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        if (playerTransform == null)
        {
            return;
        }
        Debug.DrawLine(transform.position, playerTransform.position,
        Color.red);
        Vector3 frontRayPoint = transform.position + (transform.forward *
        viewDistance);
        //Approximate perspective visualization
        Vector3 leftRayPoint = frontRayPoint;
        leftRayPoint.x += fieldOfView * 0.5f;
        Vector3 rightRayPoint = frontRayPoint;
        rightRayPoint.x -= fieldOfView * 0.5f;
        Debug.DrawLine(transform.position, frontRayPoint, Color.green);
        Debug.DrawLine(transform.position, leftRayPoint, Color.green);
        Debug.DrawLine(transform.position, rightRayPoint, Color.green);
    }
}