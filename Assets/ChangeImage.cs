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
    [SerializeField]
    GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        print(muteText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void OffOn()
    {//button.GetComponent<Image>().mainTexture = /* Texture goes here */;
     //bool pdgds = on.defaultMaterial;
        if (gameState.mute)
        {
            muteText.text = "Un mute";
        }
        else
        {
            muteText.text = "Mute";
        }
    }
}
