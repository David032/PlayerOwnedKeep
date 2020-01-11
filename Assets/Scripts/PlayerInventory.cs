using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> Inventory;

    void Start()
    {
        print(Inventory.Capacity);
        Inventory.Capacity += 1;
        Inventory.Add(new Item(0, "Test item", "Test Description"));
    }

}
