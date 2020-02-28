﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueCore : MonoBehaviour
{
    protected GameObject dialogueWindow;
    protected GameObject dialogueSpot;

    GameObject player;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogueSpot = GameObject.FindGameObjectWithTag("dialogueSpot");
        dialogueWindow = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnableController>().dialogueWindow;
    }

    public bool canTalk()
    {
        float distanceBetween = Vector3.Distance(player.transform.position, transform.position);
        if (distanceBetween < 2.75f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
