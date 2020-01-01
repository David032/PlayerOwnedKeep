using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMultiDialogueController : MonoBehaviour
{
    public List<NPCDialogue> DialogueOptions;
    public int currentOption;

    void Awake() 
    {
        UpdateOptions();
    }

    public void UpdateOptions() 
    {

    }

}
