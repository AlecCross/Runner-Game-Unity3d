using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    [SerializeField]
    Image on;
    [SerializeField]
    Image oof;
    [SerializeField]
    Text muteText;

    public void OffOn()
    {//button.GetComponent<Image>().mainTexture = /* Texture goes here */;
     //bool pdgds = on.defaultMaterial;
        if (AudioListener.pause)
        {
            FindObjectOfType<AudioManger>().Mute();
            muteText.text = "Un mute";
        }
        else
        {
            FindObjectOfType<AudioManger>().Mute();
            muteText.text = "Mute";
        }
    }
}
