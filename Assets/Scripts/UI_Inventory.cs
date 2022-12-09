using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] public List<RawImage> icons = new List<RawImage>();

    public void UpdateUI (Inventory inventory)
    {
        for (int i = 0; i < inventory.GetSize(); i++)
        {
            icons[i].texture = inventory.GetItem(i).icon.texture;
        }
    }
}
