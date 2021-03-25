using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    public Text currentScore;
    public Text hiScore;
    void Start()
    {
        currentScore.text = "CtScore " + HiScore.currentScore.ToString();
        hiScore.text = "HiScore " + HiScore.hiScore.ToString();
    }
}
