using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerInventory : MonoBehaviour
{
    public List<Item> Inventory;
    public TextMeshProUGUI inventoryText;

    void Start()
    {
        print(Inventory.Capacity);
        Inventory.Capacity += 1;
        Inventory.Add(new Item(0, "Test item", "Test Description"));
    }

    private void Update()
    {
        inventoryText.text = "";
        foreach (Item item in Inventory)
        {
            inventoryText.text += item.name;
            inventoryText.text += "\n";

        }
    }

}
