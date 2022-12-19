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

    public void AddItems(Item item)
    {
        InventorySlot new_slot = new InventorySlot(item);
        items.Add(new_slot);

        JsonLoad json = new JsonLoad();
        json.LoadData();
        if (item.id == 0) {
            json.playerInfo.book = true;
        }
        else if (item.id == 1)
        {
            json.playerInfo.boots = true;
        }
        else if (item.id == 2)
        {
            json.playerInfo.present = true;
        }
        else
        {
            json.playerInfo.food = true;
        }
        json.SaveData();
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
