using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.FilePathAttribute;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;
using static UnityEditor.Progress;

public class Player : MonoBehaviour
{
    public GameObject health_manager;

    private Vector3 moveDirection;
    public float speed = 0.005f;
    private Rigidbody rb;

    public Inventory inventory;
    [SerializeField] public List<RawImage> icons = new List<RawImage>(new RawImage[4]);

    //для вращения
    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";
    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }
    [Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;

    Camera c;

    void Start()
    {
        inventory = gameObject.AddComponent<Inventory>();
        rb = gameObject.GetComponent<Rigidbody>();
        c = Camera.main;

        JsonLoad json = new JsonLoad();
        json.LoadData();
        //загрузка положения и поворота персонажа
        transform.position = new Vector3(json.playerInfo.x, json.playerInfo.y, json.playerInfo.z);
        transform.eulerAngles = new Vector3(json.playerInfo.rotate_x, json.playerInfo.rotate_y, json.playerInfo.rotate_z);
        c.transform.position = transform.position;
        c.transform.eulerAngles = transform.eulerAngles;

        //загрузка иконок инвентаря
        if (json.playerInfo.book == true)
        {
            Item item1 = new Item();
            item1.id = 0;
            inventory.AddItems(item1);
        }
        if (json.playerInfo.boots == true)
        {
            Item item1 = new Item();
            item1.id = 1;
            inventory.AddItems(item1);
        }
        if (json.playerInfo.present == true)
        {
            Item item1 = new Item();
            item1.id = 2;
            inventory.AddItems(item1);
        }
        if (json.playerInfo.food == true)
        {
            Item item1 = new Item();
            item1.id = 3;
            inventory.AddItems(item1);
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < inventory.GetSize(); i++)
        {
            icons[inventory.GetItem(i).id].enabled = true;
        }
    }

    void SimpleMovement()
    {
        moveDirection = Vector3.zero;
        if (Input.GetKeyDown("s"))
        {
            moveDirection += -transform.forward;
        }

        if (Input.GetKeyDown("w"))
        {
            moveDirection += transform.forward;
        }

        if (Input.GetKeyDown("a"))
        {
            moveDirection += -transform.right;
        }

        if (Input.GetKeyDown("d"))
        {
            moveDirection += transform.right;
        }
        //print(moveDirection);
        moveDirection *= speed;
        if (moveDirection != Vector3.zero) {
           rb.MovePosition(transform.position + moveDirection);
        }
        transform.position = new Vector3(transform.position.x, 4, transform.position.z);
    }

    void Rotate()
    {
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQuat * yQuat;

        c.transform.rotation = transform.rotation;
    }

    public void Check()
    {
        if (inventory.GetSize() == 4)
        {
            SceneManager.LoadScene("Win");
        }
    }

    void Update()
    {
        //перемещение
        SimpleMovement();
        Rotate();
    }
}
