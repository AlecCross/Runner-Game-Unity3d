using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    //AudioClip hover;
    //AudioClip press;
    public void HoverSound()
    {
        FindObjectOfType<AudioManger>().Play("HoverButton"); 
    }
    public void PressSound()
    {
        FindObjectOfType<AudioManger>().Play("PressButton");
    }
}
