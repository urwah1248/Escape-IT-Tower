using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Start(){
        
        Cursor.visible = true;
    }
    public void Replay(){
        SceneManager.LoadScene("MainScene");
    }
    public void Menu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGameGame(){
        Application.Quit();
    }
}
