using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    //Player's head
    public GameObject targetPoint;

    public bool panL;
    bool panR;
    bool PanU;
    bool panD;

    public void PanLeft(InputAction.CallbackContext context) 
    {
        panL = !panL;
        while (panL)
        {
            transform.RotateAround(targetPoint.transform.position, transform.up, 10f);
            transform.LookAt(targetPoint.transform);
        }
    }
    public void PanRight(InputAction.CallbackContext context) 
    {
        transform.RotateAround(targetPoint.transform.position, transform.up, -10f);
        transform.LookAt(targetPoint.transform);
    }
    public void PanUp(InputAction.CallbackContext context)
    {
        transform.RotateAround(targetPoint.transform.position, transform.right, -10f);
        transform.LookAt(targetPoint.transform);
    }
    public void PanDown(InputAction.CallbackContext context)
    {
        transform.RotateAround(targetPoint.transform.position, transform.right, 10f);
        transform.LookAt(targetPoint.transform);
    }
}
