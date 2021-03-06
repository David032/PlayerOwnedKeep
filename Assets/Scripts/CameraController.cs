﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    //Player's head
    public GameObject targetPoint;

    public void PanLeft(InputAction.CallbackContext context) 
    {
        transform.RotateAround(targetPoint.transform.position, transform.up, 10f);
        transform.LookAt(targetPoint.transform);
    }
    public void PanRight(InputAction.CallbackContext context) 
    {
        transform.RotateAround(targetPoint.transform.position, transform.up, -10f);
        transform.LookAt(targetPoint.transform);
    }
    public void PanUp(InputAction.CallbackContext context)
    {
        transform.RotateAround(targetPoint.transform.position, transform.right, 10f);
        transform.LookAt(targetPoint.transform);
        floorcheck();
    }
    public void PanDown(InputAction.CallbackContext context)
    {
        transform.RotateAround(targetPoint.transform.position, transform.right, -10f);
        transform.LookAt(targetPoint.transform);
        floorcheck();
    }

    void floorcheck() 
    {
        Vector3 currentPos = transform.position;
        if (transform.position.x < 0)
        {
            transform.position.Set(0, currentPos.y, currentPos.z);
        }
    }
}
