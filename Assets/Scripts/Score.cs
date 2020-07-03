using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int score;
    void Start()
    {
        scoreText = GetComponent<Text>();
    }
    void Update()
    {
        if (scoreText != null) scoreText.text = " " + score + " ";
    }

 
}

