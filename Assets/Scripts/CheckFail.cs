using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFail : MonoBehaviour
{
    private JsonLoad json;

    void Start()
    {
        json = new JsonLoad();
        json.LoadData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (json.playerInfo.lifes <= 0)
            {
                SceneManager.LoadScene("Fail");
            }
            else
            {
                SceneManager.LoadScene("Main_scene");
            }
        }
    }
}
