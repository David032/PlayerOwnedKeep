﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

public class ChestController : MonoBehaviour
{
    public string ExamineText = "This is some pretty boring examine text";
    public GameObject PopUp;
    public Transform Chestspot;

    bool isBeingExamined = false;

    //This is barely working :(
    void OnMouseDown() 
    {
        if (!isBeingExamined)
        {
            Debug.Log(ExamineText);
            Quaternion rot = Quaternion.Euler(0, 0, 0);
            Vector3 position = Vector3.zero;
            GameObject examineWindow = Instantiate(PopUp, Chestspot.position, rot,transform);
            examineWindow.transform.localScale.Set(0.1f, 0.1f, 0.1f);
            examineWindow.GetComponent<PopUpController>().SetText(ExamineText);
            isBeingExamined = true;
        }
    }
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        isBeingExamined = false;
    }
}
