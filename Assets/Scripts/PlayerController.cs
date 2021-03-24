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
        if (Input.GetKeyDown(KeyCode.A) && targetPos.x > - laneOffset && !gameState.gameover)
        {
            //StartCoroutine(LeftOffset());
            animator.SetTrigger("LeftOffset");
            targetPos = new Vector3(targetPos.x - laneOffset,
                                        transform.position.y,
                                        transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D) && targetPos.x < laneOffset && !gameState.gameover)
        {
            //StartCoroutine(RightOffset());
            animator.SetTrigger("RightOffset");
            targetPos = new Vector3(targetPos.x + laneOffset,
                                        transform.position.y,
                                        transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !gameState.gameover)
        {
            animator.SetTrigger("RunJump");
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
        gameState.gameover = false;
        animator.SetTrigger("Ready");
        animator.SetTrigger("Run");
        //RoadGenerator.instance.StartLevel();
    }
    public void ResetGame()
    {
        gameState.gameover = false;
        animator.SetTrigger("Stop");
        transform.position=startGamePosition;
        transform.rotation=startGameRotation;
        //gameState.gameover = false;
    }
    IEnumerator EndGame()
    {
        print("GameOver");
        if (gameState.gameover)
        {
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
