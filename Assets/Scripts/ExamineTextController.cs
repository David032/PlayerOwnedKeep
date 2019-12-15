using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExamineTextController : MonoBehaviour
{
    public TextMeshProUGUI InteractWithText;
    public TextMeshProUGUI InteractingWithText;

    // Start is called before the first frame update
    void Start()
    {
        InteractWithText = GameObject.FindGameObjectWithTag("InteractExamine").GetComponent<TextMeshProUGUI>();
        InteractingWithText = GameObject.FindGameObjectWithTag("InteractThing").GetComponent<TextMeshProUGUI>();
    }

    void OnMouseOver() 
    {
        if (this.tag == "NPC")
        {
            InteractWithText.text = "Talk to: ";
            InteractingWithText.text = gameObject.name;
        }
        if (this.tag == "Chest")
        {
            InteractWithText.text = "Search: ";
            InteractingWithText.text = gameObject.name;
        }
    }

    void OnMouseExit() 
    {
        InteractWithText.text = "";
        InteractingWithText.text = "";
    }
}
