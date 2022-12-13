using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.FilePathAttribute;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public GameObject health_manager;

    private Vector3 moveDirection = Vector3.zero;
    public float speed = 0.001F;
    //public float sensitivity = 1f;

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


    public float movement_Speed;
    public static float xMove, zMove;
    Camera c;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        inventory = gameObject.AddComponent<Inventory>();
        c = Camera.main;
    }

    public void UpdateUI()
    {
        for (int i = 0; i < inventory.GetSize(); i++)
        {
            icons[i].texture = inventory.GetItem(i).icon.texture;
        }
    }

    void SimpleMovement()
    {
        if (Input.GetKeyDown("s"))
        {
            if (Input.GetKeyDown("a"))
            {
                moveDirection = -transform.forward - transform.right;
            }
            else if (Input.GetKeyDown("d"))
            {
                moveDirection = -transform.forward + transform.right;
            }
            else
            {
                moveDirection = -transform.forward;
            }
            moveDirection *= speed;
            controller.Move(moveDirection);
        }

        if (Input.GetKeyDown("w"))
        {
            if (Input.GetKeyDown("a"))
            {
                moveDirection = transform.forward - transform.right;
            }
            else if (Input.GetKeyDown("d"))
            {
                moveDirection = transform.forward + transform.right;
            }
            else
            {
                moveDirection = transform.forward;
            }
            moveDirection *= speed;
            controller.Move(moveDirection);
        }

        if (Input.GetKeyDown("a"))
        {
            moveDirection = -transform.right;
            moveDirection *= speed;
            controller.Move(moveDirection);
        }

        if (Input.GetKeyDown("d"))
        {
            moveDirection = transform.right;
            moveDirection *= speed;
            controller.Move(moveDirection);
        }
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


    void Update()
    {
        //перемещение
        SimpleMovement();
        Rotate();
        

        for (int i = 0; i < inventory.GetSize(); i++)
        {
            icons[i].texture = inventory.GetItem(i).icon.texture;
            icons[i].enabled = true;
        }
        
    }
}
