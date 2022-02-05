using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    private string playerName;
    private InputField inputName;

    private void Start()
    {
        inputName = GameObject.Find("PlayerName").GetComponent<InputField>();
        inputName.text = NameManager.nameManager.playerName;
    }
    public void NameEdit(string name)
    {
        playerName = name;
    }

    // Saves the username and starts the game
    public void Startnew()
    {
        if (playerName != null)
        {
            NameManager.nameManager.playerName = playerName; 
        }
              
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        NameManager.nameManager.SaveToFile();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}   
