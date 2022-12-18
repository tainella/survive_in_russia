using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEngine.UIElements.UxmlAttributeDescription;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class NPC : MonoBehaviour
{ 
    public int id;
    private bool met_babka;
    private bool met_mamka;
    private bool met_gopnik;

    public void Start()
    {
        /*
        met_babka = ;
        met_mamka = ;
        met_gopnik = ;
         */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (id == 0 && (met_mamka == false)) //мама
        {
            SceneManager.LoadScene("mamka");
        }
        else if (id == 1 && (met_gopnik == false)) //гопник
        {
            SceneManager.LoadScene("gopnik");
        }
        else if (id == 2 && (met_babka == false)) //старушка
        {
            SceneManager.LoadScene("babka");
        }
    }

}