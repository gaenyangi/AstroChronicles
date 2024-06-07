using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Score : MonoBehaviour
{
    public static int score;
    public static int killcount;
    public TMP_Text scoreText;

    private void Start()
    {
        killcount = 0;
    }


    // Update is called once per frame
    void Update()
    {
        scoreText.text = "KillCount : " + killcount;
        score = killcount;
        HighScore();
    }

    void HighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    
}
