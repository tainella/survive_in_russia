using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private List<Image> icons = new List<Image>();

    public void UpdateUI (Inventory inventory)
    {
        for (int i = 0; i < inventory.GetSize(); i++)
        {
            icons[i].sprite = inventory.GetItem(i).icon;
        }
    }
}
