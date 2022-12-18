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
    	   SceneManager.LoadScene("babka_fail");
    	}
    	
    }
}
