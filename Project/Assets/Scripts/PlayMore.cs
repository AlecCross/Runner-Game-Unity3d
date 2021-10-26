using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMore : MonoBehaviour
{
    public void LoadMainScene()
    {
        FindObjectOfType<AudioManger>().StopAllAudio();
        SceneManager.LoadScene("MainScene");
    }
}