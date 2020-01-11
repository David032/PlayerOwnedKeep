using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public int id;
    public string name;
    public string description;

    public Item(int numID,string ItemName, string ItemDescription) 
    {
        id = numID;
        name = ItemName;
        description = ItemDescription;
    }

    public int getId() { return id; }
    public string getName() { return name; }
    public string getDescription() { return description; }
}
