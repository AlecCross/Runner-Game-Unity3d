using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowHiScore : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadHiScore()
    {
        SceneManager.LoadScene("HiScore");
    }
}
