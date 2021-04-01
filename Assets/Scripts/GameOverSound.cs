using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSound : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManger>().StopAllAudio();
        FindObjectOfType<AudioManger>().Play("GameOver");
    }
}
