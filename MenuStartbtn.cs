using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStartbtn : MonoBehaviour
{
    public TMP_Text highscore;
    private void Start()
    {
        if(highscore != null)
        {
            highscore.text = "Your best kills : " + PlayerPrefs.GetInt("HighScore", 0);
        }
    }
    public void OnPlaybtn()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnQuitbtn()
    {
        Application.Quit();
    }

    public void OnMenubtn()
    {
        SceneManager.LoadScene(0);
    }
}
