using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public bool gameover;
    public bool victory;
    public Animator curtainAnimator;

    private void Start()
    {
        //curtainAnimator.SetTrigger("CurtainHandling");
        //curtainAnimator.StopPlayback();
    }
    private void FixedUpdate()
    {
        if (gameover)
        {
            StartCoroutine(GameOver());
        }
    }
    public void StartScene()
    {
        StartCoroutine(StartCor());
    }
    public void RestartScene()
    {
        StartCoroutine(RestartCor());
    }
    IEnumerator StartCor()
    {
        print("Start-SetTrigger(CurtainUp)");
        curtainAnimator.SetTrigger("CurtainUp");
        yield return new WaitForSeconds(1f);
        print("Start-SetTrigger(CurtainHide)");
        curtainAnimator.SetTrigger("CurtainHide");
        //curtainAnimator.SetTrigger("CurtainIdle");
    }
    IEnumerator RestartCor()
    {
        print("Restart-SetTrigger(CurtainDown)");
        curtainAnimator.SetTrigger("CurtainDown");
        yield return new WaitForSeconds(1f);
        print("Restart-SetTrigger(CurtainHandling)");
        curtainAnimator.SetTrigger("CurtainHandling");
        SceneManager.LoadSceneAsync("MainScene");
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2.1f);
        SceneManager.LoadSceneAsync("GameOverScene");
    }
}
