using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFinal : MonoBehaviour
{
    public Text scoreFinal;
    void Start()
    {
        scoreFinal = GetComponent<Text>();
    }
    void Update()
    {
        if (scoreFinal != null) scoreFinal.text = "Score: " + Score.score + " ";
    }

 
}