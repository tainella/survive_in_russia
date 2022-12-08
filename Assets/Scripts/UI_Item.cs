using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class UI_Item : MonoBehaviour
{
    public RawImage prefabUI;
    private RawImage uiUse;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        uiUse = Instantiate(prefabUI, FindObjectOfType<Canvas>().transform).GetComponent<RawImage>();
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        uiUse.transform.position = cam.WorldToScreenPoint(target.position);
    }
}
