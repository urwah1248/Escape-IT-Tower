using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject credits;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene("MainScene");
    }
    public void OpenCredits(){
        credits.SetActive(true);
    }
    public void CloseCredits(){
        credits.SetActive(false);
    }
    public void ExitGame(){
        Application.Quit();
    }
}
