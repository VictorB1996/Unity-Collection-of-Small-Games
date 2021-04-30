﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 10;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text =  score.ToString();

    }

    //Disable text if level passed
    public void DisableScoreText()
    {
        if(score == 0)
        {
            scoreText.gameObject.SetActive(false);
        }
    }
}
