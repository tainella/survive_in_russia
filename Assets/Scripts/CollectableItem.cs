using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class CollectableItem : MonoBehaviour
{
    [SerializeField] private Item item;

    private void OnTriggerEnter(Collider other)
    {
        if (!item) return;

        var inventory = other.GetComponent<Inventory>();

        if (inventory)
        {
            inventory.AddItems(item);
            Destroy(gameObject);
        }
    }

}
