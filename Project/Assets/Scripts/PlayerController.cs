using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Vector3 startGamePosition;
    Quaternion startGameRotation;
    Vector3 targetPos;
    public GameObject gameManager;
    GameState gameState;
    float laneOffset = 1f;
    float laneChangeSpeed = 15;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        startGamePosition = transform.position;
        startGameRotation = transform.rotation;
        targetPos = transform.position;
        gameState = gameManager.GetComponent<GameState>();
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.A)
            ||Input.GetKeyDown(KeyCode.LeftArrow)
            || SwipeManager.swipeLeft
            && targetPos.x > - laneOffset 
            && !gameState.gameover)
        {
            //StartCoroutine(LeftOffset());
            animator.SetTrigger("LeftOffset");
            targetPos = new Vector3(targetPos.x - laneOffset,
                                        transform.position.y,
                                        transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D) 
            || Input.GetKeyDown(KeyCode.RightArrow) 
            || SwipeManager.swipeRight
            && targetPos.x < laneOffset 
            && !gameState.gameover)
        {
            //StartCoroutine(RightOffset());
            animator.SetTrigger("RightOffset");
            targetPos = new Vector3(targetPos.x + laneOffset,
                                        transform.position.y,
                                        transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space)
            || SwipeManager.swipeUp
            && !gameState.gameover)
        {
            StartCoroutine(JumpSound());
        }
        if (gameState.gameover)
        {
            StartCoroutine(EndGame());
        }
        transform.position = Vector3.MoveTowards(transform.position,
                                                    targetPos,
                                                    laneChangeSpeed * Time.deltaTime);
        
    }
    public void StartGame()
    {
        if (!gameState.run)
        {
            gameState.run = true;
            StartCoroutine(RunSound());
            gameState.gameover = false;
            animator.SetTrigger("Ready");
            animator.SetTrigger("Run");
            FindObjectOfType<AudioManger>().StopAllAudio();
            FindObjectOfType<AudioManger>().Play("RunningMusic");
        }
        //RoadGenerator.instance.StartLevel();
    }
    IEnumerator RunSound()
    {
        yield return new WaitForSeconds(1.65f);
        FindObjectOfType<AudioManger>().Play("Run");
    }
    IEnumerator JumpSound()
    {
        FindObjectOfType<AudioManger>().MuteByName("Run");
        animator.SetTrigger("Jump"); 
        yield return new WaitForSeconds(0.8f);
        FindObjectOfType<AudioManger>().UnMuteByName("Run");
    }
    public void ResetGame()
    {
        gameState.run = false;
        FindObjectOfType<AudioManger>().StopAllAudio();
        gameState.gameover = false;
        animator.SetTrigger("Stop");
        transform.position=startGamePosition;
        transform.rotation=startGameRotation;
        //gameState.gameover = false;
    }
    IEnumerator EndGame()
    {
        //print("GameOver");
        if (gameState.gameover)
        {
            gameState.run = false;
            animator.SetTrigger("SweepFallOn");
        }
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("Laying");
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("Idle");
    }
    //IEnumerator LeftOffset()
    //{
    //    StopAllCoroutines();
    //    animator.SetTrigger("LeftOffset");
    //    targetPos = new Vector3(targetPos.x - laneOffset,
    //                                transform.position.y,
    //                                transform.position.z);
    //    StopCoroutine(LeftOffset());
    //    yield return new WaitForSeconds(0.001f);
    //}
    //IEnumerator RightOffset()
    //{
    //    StopAllCoroutines();
    //    animator.SetTrigger("RightOffset");
    //    targetPos = new Vector3(targetPos.x + laneOffset,
    //                                transform.position.y,
    //                                transform.position.z);
    //    StopCoroutine(RightOffset());
    //    yield return new WaitForSeconds(0.001f);
    //}
}
