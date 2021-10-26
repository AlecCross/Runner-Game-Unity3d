using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    [SerializeField]
    static bool isPaused;
    [SerializeField]
    GameObject pauseMenu;
    public Text currentScore;
    public Text hiScore;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Нажат Esc ");
            if (isPaused) Resume();
            else          PauseTime();
        }
        currentScore.text = "CtScore "+HiScore.currentScore.ToString();
        hiScore.text = "HiScore " + HiScore.hiScore.ToString();
    }
    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    void PauseTime()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
