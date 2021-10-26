using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHiScore : MonoBehaviour
{
    [SerializeField]
    Text hiScore;
    void Start()
    {
        hiScore.text = HiScore.hiScore.ToString();
    }
}
