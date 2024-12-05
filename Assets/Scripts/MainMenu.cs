using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string userName;
    public InputField inputName;
    public Text HighScore;

    // Start is called before the first frame update
    void Start()
    {
        userName.text = DataManager.userName;

        HighScore.text = $"1. {DataManager.scoreTable[0]} {DataManager.scoreTable[1]} \n 2. {DataManager.scoreTable[2]} {DataManager.scoreTable[3]} \n 3. {DataManager.scoreTable[4]} {DataManager.scoreTable[5]} \n 5. {DataManager.scoreTable[6]} {DataManager.scoreTable[7]} \n 8. {DataManager.scoreTable[8]} {DataManager.scoreTable[9]} \n ";
    }

    public void UpdateName()
    { 
        userName.text = inputName.text;
        DataManager.userName = userName.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    { 
        DataManager.instance.SaveGame();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
