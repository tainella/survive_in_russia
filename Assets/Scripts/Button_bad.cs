using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_bad : MonoBehaviour
{
    // Start is called before the first frame update
       void Start () {
	    Button btn = GetComponent<Button>();
	    btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
	    Debug.Log ("You have clicked the bad button!");
	    JsonLoad json =new JsonLoad();
	    json.LoadData();
	    json.playerInfo.lifes-=1;
	    json.SaveData();
	    SceneManager.LoadScene("gopnik_fail"); 
		
	}
}
