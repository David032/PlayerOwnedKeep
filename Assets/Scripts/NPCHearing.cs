using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class NPCHearing : Sense
{
    SphereCollider hearingRange;
    protected override void Initialize()
    {
        hearingRange = GetComponent<SphereCollider>();
    }
    protected override void UpdateSense()
    {
        //elapsedTime += Time.deltaTime;
        //if (elapsedTime >= detectionRate)
        //{
        //    listen();
        //}
    }

    void OnTriggerEnter(Collider other)
    {
            
    }
}


