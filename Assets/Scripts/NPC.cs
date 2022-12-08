using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UIElements.UxmlAttributeDescription;

[RequireComponent(typeof(SphereCollider))]
public class NPC : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if (id == 0) //гопник ж
        {
            //SceneManager.LoadScene("NPC_0");
        }
        else if (id == 1) //гопник м
        {
            //SceneManager.LoadScene("NPC_1");
        }
        else if (id == 2) //старушка 1
        {
            //SceneManager.LoadScene("NPC_2");
        }
        else if (id == 3) //старушка 2
        {
            //SceneManager.LoadScene("NPC_3");
        }
        else if (id == 4) //птицы
        {
            //SceneManager.LoadScene("NPC_4");
        }

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
