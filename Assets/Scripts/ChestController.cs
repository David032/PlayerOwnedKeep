using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

public class ChestController : MonoBehaviour
{
    public string ExamineText = "This is some pretty boring examine text";
    public GameObject PopUp;


    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log(ExamineText);
        GameObject examineWindow = Instantiate(PopUp,transform);
        examineWindow.GetComponent<PopUpController>().SetText(ExamineText);
    }
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        
    }
}
