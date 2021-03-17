using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Vector3 startGamePosition;
    Quaternion startGameRotation;
    Vector3 targetPos;
    float laneOffset = 1f;
    float laneChangeSpeed = 15;
    void Start()
    {
        animator = GetComponent<Animator>();
        startGamePosition = transform.position;
        startGameRotation = transform.rotation;
        targetPos = transform.position;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && targetPos.x > - laneOffset)
        {
            targetPos = new Vector3(targetPos.x - laneOffset,
                                    transform.position.y,
                                    transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D) && targetPos.x < laneOffset)
        {
            targetPos = new Vector3(targetPos.x + laneOffset,
                                    transform.position.y,
                                    transform.position.z);
        }
        transform.position = Vector3.MoveTowards(transform.position,
                                                    targetPos,
                                                    laneChangeSpeed * Time.deltaTime);
    }
    public void StartGame()
    {
        animator.SetTrigger("Ready");
        //RoadGenerator.instance.StartLevel();
    }
    public void ResetGame()
    {
        animator.SetTrigger("Idle");
        transform.position=startGamePosition;
        transform.rotation=startGameRotation;
    }
}
