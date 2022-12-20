using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class Button_play : MonoBehaviour
{
	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Debug.Log("You have clicked the Play button!");
		JsonLoad json = new JsonLoad();
		json.CreateDefaultPlayerData();
		SceneManager.LoadScene("Intro");
	}
}
