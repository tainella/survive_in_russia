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

    public static float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360F) && (angle <= 360F))
        {
            if (angle < -360F)
            {
                angle += 360F;
            }
            if (angle > 360F)
            {
                angle -= 360F;
            }
        }
        return Mathf.Clamp(angle, min, max);
    }

    void Update()
    {
        //перемещение
        if (Input.GetKeyDown("s"))
        {
            if (Input.GetKeyDown("a"))
            {
                moveDirection = new Vector3(-1, 0, -1);
            }
            else if (Input.GetKeyDown("d"))
            {
                moveDirection = new Vector3(1, 0, -1);
            }
            else
            {
                moveDirection = new Vector3(0, 0, -1);
            }
             moveDirection *= speed;
             controller.Move(moveDirection);
        }

        if (Input.GetKeyDown("w"))
        {
            if (Input.GetKeyDown("a"))
            {
                moveDirection = new Vector3(-1, 0, 1);
            }
            else if (Input.GetKeyDown("d"))
            {
                moveDirection = new Vector3(1, 0, 1);
            }
            else
            {
                moveDirection = new Vector3(0, 0, 1);
            }
            moveDirection *= speed;
            controller.Move(moveDirection);
        }

        if (Input.GetKeyDown("a"))
        {
            moveDirection = Vector3.left;
            moveDirection *= speed;
            controller.Move(moveDirection);
        }

        if (Input.GetKeyDown("d"))
        {
            moveDirection = Vector3.right;
            moveDirection *= speed;
            controller.Move(moveDirection);
        }

        /*
        //вращение
        c.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        c.Rotate(-Input.GetAxis("Mouse Y") * sensitivity, 0, 0);
        var CharacterRotation = c.rotation;
        CharacterRotation.y = 0;
        transform.rotation = CharacterRotation;
        */

        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQuat * yQuat;

        c.transform.rotation = transform.rotation;


        for (int i = 0; i < inventory.GetSize(); i++)
        {
            icons[i].texture = inventory.GetItem(i).icon.texture;
            icons[i].enabled = true;
        }
    }
}
