using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCDialogue : NPCDialogueCore
{
    public string iD;
    public string windowText = "";
    public bool displayLeft = true;
    public bool displayRight = false;

    GameObject spawnedDialogue;

    void Start() 
    {
    
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(spawnedDialogue);
            spawnedDialogue = null;
            this.gameObject.GetComponent<NPCMultiDialogueController>().UpdateOptions();
        }
    }

    void OnMouseDown() 
    {
        if (canTalk())
        {
            GameObject DialogueWindow = Instantiate(dialogueWindow, dialogueSpot.transform.position, dialogueSpot.transform.rotation, dialogueSpot.transform); ;
            DialogueWindow.name = this.gameObject.ToString() + " Dialogue";
            DialogueWindow.GetComponent<DialogueInstance>().NewDialogueInstance(displayLeft, displayRight, windowText);
            this.gameObject.GetComponent<NPCMultiDialogueController>().UpdateOptions();
            spawnedDialogue = DialogueWindow;
        }
    }
}
