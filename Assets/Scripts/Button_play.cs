using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_play : MonoBehaviour
{
    //public Button yourButton;

	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Debug.Log("You have clicked the Play button!");
		SceneManager.LoadScene("Game");
	}
}
