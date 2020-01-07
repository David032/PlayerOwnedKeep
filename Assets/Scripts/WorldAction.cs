using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class WorldAction : BaseEvent
{
    public string message = "";
    public float accessRange;

    GameObject spawnedDialogue;

    void Start()
    {
        AssignElements();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        float distanceBetween = Vector3.Distance(player.transform.position, transform.position);
        if (distanceBetween < accessRange)
        {
            player.GetComponent<NavMeshAgent>().enabled = false;
            spawnedDialogue = Instantiate(dialogueWindow, dialogueSpot.transform);
            spawnedDialogue.GetComponent<RectTransform>().localPosition.Set(0, 0, 0);
            spawnedDialogue.GetComponent<DialogueInstance>().NewDialogueInstance(false, true, message, player);
            spawnedDialogue.GetComponent<DialogueInstance>().button.GetComponent<Button>().onClick.RemoveAllListeners();
            spawnedDialogue.GetComponent<DialogueInstance>().button.GetComponent<Button>().onClick.AddListener(OnDialogueEnd);   
        }
        else
        {      
        }
    }

    public void OnDialogueEnd() 
    {
        player.GetComponent<NavMeshAgent>().enabled = true;
        CreateEvent();
        Destroy(spawnedDialogue);
    }
}
