using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!pauseMenu.activeSelf){
                Pause();
            }
            else{
                Continue();
            }
        }
    }

    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        player.SetActive(false);
        Cursor.visible = true;
    }
    public void Continue(){
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        player.SetActive(true);
    }

    public void ExitToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
