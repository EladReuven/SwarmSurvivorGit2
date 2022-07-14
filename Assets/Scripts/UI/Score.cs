using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    private static int highScore = 0;
    public TextMeshProUGUI scoreText; 
    public int points = 0;

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        if(scoreText != null)
        scoreText.text = "Highest Score: " + highScore + "!!!";
    }

    public void updateHighScore()
    {
        if(highScore < points)
        {
            highScore = points;
        }
    }


}
