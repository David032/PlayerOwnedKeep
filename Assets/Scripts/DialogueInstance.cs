using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueInstance : MonoBehaviour
{
    public GameObject button;
    public GameObject leftWindow;
    public TextMeshProUGUI leftText;
    public GameObject rightWindow;
    public TextMeshProUGUI rightText;
    public TextMeshProUGUI dialogueText;

    public void Awake()
    {
        
    }

    public void NewDialogueInstance(bool left, bool right, string text, GameObject caller) 
    {
        dialogueText.text = text;
        if (left)
        {
            leftWindow.SetActive(true);
            rightWindow.SetActive(false);
        }
        if (right)
        {
            leftWindow.SetActive(false);
            rightWindow.SetActive(true);
        }

        leftText.text = caller.name;
        rightText.text = caller.name;

        button.GetComponent<Button>().onClick.AddListener(EndDialogue);
    }

    public void EndDialogue() 
    {
        Destroy(this.gameObject);
    }
}
