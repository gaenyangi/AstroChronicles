using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowingHighScore : MonoBehaviour
{
    public TMP_Text HighScore;
    public TMP_Text thisKillcount;
    
    void Start()
    {
        HighScore.text = "Your Best Kills : " + PlayerPrefs.GetInt("HighScore", 0);
        thisKillcount.text = "Your bravery killed " + Score.killcount + " enemy this time";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
