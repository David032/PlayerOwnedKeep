using UnityEngine;

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
        }
    }

    void OnMouseDown() 
    {
        if (canTalk())
        {
            GameObject DialogueWindow = Instantiate(dialogueWindow, dialogueSpot.transform.position, dialogueSpot.transform.rotation, dialogueSpot.transform); ;
            DialogueWindow.name = this.gameObject.ToString() + " Dialogue";
            DialogueWindow.GetComponent<DialogueInstance>().NewDialogueInstance(displayLeft, displayRight, windowText);
            spawnedDialogue = DialogueWindow;
        }
    }
}
