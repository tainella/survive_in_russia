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
        if (s.Trim() == "1917")
        {
            SceneManager.LoadScene("Granny_win");
        }
        else
        {
            JsonLoad json = new JsonLoad();
            json.LoadData();
            json.playerInfo.lifes -= 1;
            json.SaveData();
            SceneManager.LoadScene("Granny_fail");
        }
    	
    }
}
