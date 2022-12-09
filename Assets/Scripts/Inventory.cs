using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System.Drawing;
using UnityEngine.EventSystems;

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
    [SerializeField] public UnityEvent OnInventoryChanges;

    public void AddItems(Item item)
    {
        InventorySlot new_slot = new InventorySlot(item);
        items.Add(new_slot);

        OnInventoryChanges.Invoke();
    }

    public Item GetItem(int i)
    {
        return items[i].item;
    }

    public int GetSize()
    {
        return items.Count;
    }
}
