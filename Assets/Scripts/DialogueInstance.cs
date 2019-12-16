using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueInstance : MonoBehaviour
{
    public GameObject button;
    public GameObject leftWindow;
    public GameObject rightWindow;
    public MeshRenderer leftCharacter;
    public MeshRenderer rightCharacter;
    public TextMeshPro dialogueText;

    public void NewDialogueInstance(bool left, bool right, string text) 
    {
        dialogueText.text = text;
        if (left)
        {
            leftWindow.SetActive(true);
            rightWindow.SetActive(false);
            leftCharacter.gameObject.SetActive(true);
            rightCharacter.gameObject.SetActive(false);
        }
        if (right)
        {
            leftWindow.SetActive(false);
            rightWindow.SetActive(true);
            leftCharacter.gameObject.SetActive(false);
            rightCharacter.gameObject.SetActive(true);
        }
    }

    //Maybe don't use this one yet?
    void NewDialogueInstance(bool left, bool right, Material leftMat, Material rightMat, string text) 
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
    }

    public void EndDialogue() 
    {
        Destroy(this.gameObject);
    }
}
