using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueCore : MonoBehaviour
{
    public GameObject dialogueWindow;
    public GameObject dialogueSpot;

    GameObject player;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public bool canTalk()
    {
        float distanceBetween = Vector3.Distance(player.transform.position, transform.position);
        if (distanceBetween > 2.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
