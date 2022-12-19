using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ReadInput : MonoBehaviour
{
    private string input;
    
    
    public void GetText( string s)
    {
    	if (s.Trim()=="1917"){
    	   SceneManager.LoadScene("main_scene");
    	   
    	}
    	else
    	{
    	   print("start");
    	   JsonLoad json= new JsonLoad();
    	   json.LoadData();
    	   json.playerInfo.lifes -=1;
    	   json.SaveData();
    	   SceneManager.LoadScene("babka_faill");
    	}
    	
    }
}
