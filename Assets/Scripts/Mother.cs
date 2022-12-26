using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mother : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JsonLoad json = new JsonLoad();
            json.LoadData();
            json.playerInfo.lifes = 0;
            json.SaveData();
            SceneManager.LoadScene("Fail");
        }
    }
}
