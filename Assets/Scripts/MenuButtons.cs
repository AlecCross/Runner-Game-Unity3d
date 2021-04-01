using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{
    public void BackToGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadHiScore()
    {
        SceneManager.LoadScene("HiScore");
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
