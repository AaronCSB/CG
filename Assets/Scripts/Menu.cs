using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject menu;

    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseGame();
        }
    }

    public void pauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            menu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            resumeGame();
        }
    }

    public void resumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;  

    }

    public void quitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;    
        Application.Quit();                                 

    }

    public void restartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
