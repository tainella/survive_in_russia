using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoToScene());
    }

    // Update is called once per frame
    IEnumerator GoToScene()
    {
       print("hello");
       yield return new WaitForSeconds(3);
       JsonLoad json= new JsonLoad();
       json.LoadData();
       if (json.playerInfo.lifes <= 0){
           SceneManager.LoadScene("Fail");
       }
       else{
           SceneManager.LoadScene("main_scene");
       }
       
    }
}
