using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    
    public GameObject pauseMenuUi;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUi.SetActive(false);
        GameIsPaused = false;
    }
    
    void Pause()
    {
        pauseMenuUi.SetActive(true);
        GameIsPaused = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!!");
        Application.Quit();
    }
   
}
