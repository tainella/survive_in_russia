using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UIElements.UxmlAttributeDescription;

[RequireComponent(typeof(SphereCollider))]
public class CollectableItem : MonoBehaviour
{

    public RawImage prefabUI;
    private RawImage uiUse;
    Camera cam;
    private Vector3 offset = new Vector3(0, 0.5f, 0);
    private bool treeHit = false;
    private Inventory inventory;

    [SerializeField] public Item item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            uiUse.enabled = true;
            treeHit = true;
            inventory = other.gameObject.GetComponent<Inventory>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        uiUse.enabled = false;
        treeHit = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        uiUse = Instantiate(prefabUI, FindObjectOfType<Canvas>().transform).GetComponent<RawImage>();
        //prefabUI.enabled = false; 
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 item_pos = transform.position;
        item_pos.y += GetComponent<MeshRenderer>().bounds.size.y + 0.6f;
        uiUse.transform.position = Camera.main.WorldToScreenPoint(item_pos);
        if (treeHit && Input.GetKeyDown(KeyCode.E))
        {
            uiUse.enabled = false;
            inventory.AddItems(item);
            Destroy(gameObject);
        }
    }
}

