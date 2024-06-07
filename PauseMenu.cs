using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenuUI;

    private void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }            
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        IsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        IsPaused = true;
    }

    public void OnMenuBtn()
    {
        SceneManager.LoadScene(0);
    }
}
