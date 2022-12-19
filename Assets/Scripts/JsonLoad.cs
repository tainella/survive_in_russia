using System.IO;
using UnityEngine;


public class JsonLoad
{
    public PlayerInfo playerInfo;

    private string path = "";

    // Start is called before the first frame update
  
    private void SetPaths()
    {
        path = "Assets/Scripts"+ Path.AltDirectorySeparatorChar + "load_scene.json";
        //persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    public void CreateDefaultPlayerData()
    
    {
        SetPaths();
        playerInfo = new PlayerInfo(3, 0.01, 0.01, 0.01, 0.01, 0.01,0.01, false, false,false, false);
        Debug.Log("create player");
        SaveData();
        Debug.Log("svae");
    }

    

    // Update is called once per frame
   
    public void SaveData()
    {
        string savePath = path;

        Debug.Log("Saving Data at " + savePath);
        string json = JsonUtility.ToJson(playerInfo);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public void LoadData()
    {
        SetPaths();
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        PlayerInfo data = JsonUtility.FromJson<PlayerInfo>(json);
        playerInfo=data;
        Debug.Log(data.ToString());
    }
}

