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
        if ((Vector3.Angle(frontRayPoint, transform.forward)) < fieldOfView)
        {
            if (Physics.Raycast(transform.position, frontRayPoint, out hit, viewDistance))
            {
                if (hit.collider.GetComponent<EventObject>())
                {
                    if (hit.collider.GetComponent<EventObject>().EventObjectType == ObjectType.Visual)
                    {
                        if (!MentalModel.events.Contains(hit.collider.GetComponent<EventObject>().LinkedEvent))
                        {
                            MentalModel.events.Add(hit.collider.GetComponent<EventObject>().LinkedEvent);
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