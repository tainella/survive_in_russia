using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonTrueAnsw : MonoBehaviour
{
    // Start is called before the first frame update
       void Start () {
           Button btn = GetComponent<Button>();
           btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
	    Debug.Log ("You have clicked the True button!");
	    SceneManager.LoadScene("main_scene");
	}
}