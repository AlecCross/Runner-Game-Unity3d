using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int scoreCount;
    public Text scoreDisplay;
    void Start()
    {
        scoreCount = 0;
  
    }

    void Update()
    {
        scoreDisplay.text = "Score: "+ scoreCount.ToString();
    }
    public void AddScore(int score)
    {
        scoreCount += score;
    }
}
