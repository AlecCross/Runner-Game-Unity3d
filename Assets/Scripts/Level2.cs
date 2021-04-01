using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level2 : MonoBehaviour
{
    public void ToLevel2()
    {
        FindObjectOfType<AudioManger>().StopAllAudio();
        SceneManager.LoadScene("MainScene2");
    }
}
