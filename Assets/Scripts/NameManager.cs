using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{
    public static NameManager nameManager;
    public InputField inputName;
    

    public string playerName;
    public int score;

    public int highscore;
    public string highcorePlayerName;

    // Check to see if another instance of NameManager exists and make a static instance of the NameManager
    private void Awake()
    {
        if (nameManager != null)
        {
            Destroy(gameObject);
            return;
        }

        nameManager = this;
        DontDestroyOnLoad(gameObject);

        LoadFromFile();

        

        
    }
    
    public bool CheckScore(int score)
    {
        if (score > highscore)
        {
            highscore = score;
            highcorePlayerName = playerName;

            return true;
        }
        else
        {
            return false;
        }
    }


    [System.Serializable]
    public class ScoreEntry
    {
        public int score;
        public string playerName;
    }

    public class SaveData
    {
        public int highScore;
        public string name;
        public string lastUsedName;
    }

    public void SaveToFile()
    {
        SaveData data = new SaveData();
        data.highScore = NameManager.nameManager.highscore;
        data.name = NameManager.nameManager.highcorePlayerName;
        data.lastUsedName = NameManager.nameManager.playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadFromFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            NameManager.nameManager.highscore = data.highScore;
            NameManager.nameManager.highcorePlayerName = data.name;

            if (data.lastUsedName != null)
            {
                NameManager.nameManager.playerName = data.lastUsedName; 
            }
        }
    }

}
