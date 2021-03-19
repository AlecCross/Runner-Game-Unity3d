using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    int scoreCount;
    public Text scoreDisplay;
    void Start()
    {
        scoreCount = 0;
    }

    void Update()
    {
        scoreDisplay.text = "Score: " + scoreCount.ToString();
    }
    public void AddScore(int score)
    {
        scoreCount += score;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            scoreCount += 10;
            print("Начислено 10 очков Всего:"+ scoreCount);
        }
    }
}
