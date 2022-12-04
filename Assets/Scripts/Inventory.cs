using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class InventorySlot
{
    public Item item;

    public InventorySlot(Item item)
    {
        this.item = item;
    }
}

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> items = new List<InventorySlot>();

    public void AddItems(Item item)
    {
        InventorySlot new_slot = new InventorySlot(item);
        items.Add(new_slot);
    }
}
