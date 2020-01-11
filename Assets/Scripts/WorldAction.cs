using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

/// <summary>
/// Actions where clicking within range creates event
/// </summary>

public class WorldAction : BaseEvent
{
    public string message = "";
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
        if (CalculateDistance())
        {
            spawnDialogue(message);
        }
    }
}
