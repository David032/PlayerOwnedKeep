using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : BaseEvent
{
    bool actionCompleted = false;
    public string message = "";

    public int idToAdd;
    public string nameOfItem = "";
    public string descriptionOfItem = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (CalculateDistance() && !actionCompleted)
        {
            actionCompleted = true;
            spawnDialogue(message, false);
            player.GetComponent<PlayerInventory>().Inventory.Add(new Item(idToAdd, nameOfItem, descriptionOfItem));
        }
    }
}
