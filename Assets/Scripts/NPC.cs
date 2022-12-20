using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEngine.UIElements.UxmlAttributeDescription;

[RequireComponent(typeof(SphereCollider))]
public class NPC : MonoBehaviour
{ 
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            JsonLoad json = new JsonLoad();
            json.LoadData();
            json.playerInfo.x = other.transform.position.x;
            json.playerInfo.y = other.transform.position.y;
            json.playerInfo.z = other.transform.position.z;
            json.playerInfo.rotate_x = other.transform.rotation.x;
            json.playerInfo.rotate_y = other.transform.rotation.y;
            json.playerInfo.rotate_z = other.transform.rotation.z;

            if (id == 0) //мама
            {
                json.playerInfo.lifes -= 3;
                json.SaveData();
                SceneManager.LoadScene("Mamka");
            }
            else if ((id == 1) & (json.playerInfo.met_gopnik == false)) //гопник
            {
                json.playerInfo.met_gopnik = true;
                json.SaveData();
                SceneManager.LoadScene("Gopnik");
            }
            else if ((id == 2) & (json.playerInfo.met_babka == false)) //старушка
            {
                json.playerInfo.met_babka = true;
                json.SaveData();
                SceneManager.LoadScene("Babka");
            }
        }
    }

}