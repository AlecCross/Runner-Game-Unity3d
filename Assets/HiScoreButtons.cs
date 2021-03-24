using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HiScoreButtons : MonoBehaviour
{
    public Text hiScore;

    private void Start()
    {
        //hiScore = gameObject.GetComponentInChildren<HiScoreText>();
    }
    public void BackToGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ResetHiScore()
    {
        HiScore.hiScore = 0;
        hiScore.text = HiScore.hiScore.ToString();
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}