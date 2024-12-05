using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections.Concurrent;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public static string[] scoreTable = new string[10];
    public static string userName;
    
    ¨private void Awake()
    {
        if (instance != null)
        { 
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGame();
    }
    public void UpdateScore(int currentScore)
    {
        int i = 1;
        int oldScore = 0;
        string currentUser = userName;
        string oldUser;

        while (i < 10)
        {
            if (int.TryParse(scoreTable[i], out oldScore))
            {
                oldScore = int.Parse(scoreTable[i]);
            }
            else
            {
                oldScore = 0;
            }

            if (currentScore > oldScore)
            { 
                oldUser = scoreTable[i-1];
                scoreTable[i - 1] = currentUser;
                scoreTable[i] = currentScore.ToString();

                currentScore = oldScore;
                currentUser = oldUser;
            }

            i+=2;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public string userName;
        public string[] scoreTable;
    }

    public void SaveGame()
    { 
        SaveData data = new SaveData();
        data.userName = userName;
        data.scoreTable = scoreTable;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        { 
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userName = data.userName;
            scoreTable = data.scoreTable;
        }
    }
}