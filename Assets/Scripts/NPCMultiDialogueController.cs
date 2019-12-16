using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMultiDialogueController : MonoBehaviour
{
    public List<NPCDialogue> DialogueOptions;
    public int currentOption;

    void Awake() 
    {
        foreach (NPCDialogue item in this.gameObject.GetComponents<NPCDialogue>())
        {
            DialogueOptions.Add(item);
        }

        UpdateOptions();
    }

    public void UpdateOptions() 
    {
        foreach (NPCDialogue item in DialogueOptions)
        {
            item.enabled = false;
            print("Turned off dialogue " + item.iD);
        }
        DialogueOptions[currentOption].enabled = true;
        print("Turned on :" + DialogueOptions[currentOption].iD);
    }

}
