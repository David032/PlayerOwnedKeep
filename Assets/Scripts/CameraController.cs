using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Player's head
    public GameObject targetPoint;

    void Update() 
    {
        camMove();

    }

    void camMove() 
    {
        float camXInput = Input.GetAxis("CamX");
        print(camXInput);
        float camYInput = Input.GetAxis("CamY");
        print(camYInput);

        if (camXInput <= -0.2)
        {
            transform.RotateAround(targetPoint.transform.position, transform.up*-1f, 1f);
        }
        //if (camXInput >= 0.2)
        //{
        //    transform.RotateAround(targetPoint.transform.position, transform.up, -1f);
        //}

    }
}
