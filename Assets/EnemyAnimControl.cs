using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimControl : MonoBehaviour
{
    public Animator animator;
    public GameObject gameManager;
    GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = gameManager.GetComponent<GameState>();
        animator.SetTrigger("Go");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.gameover)
        {
            print("ГАМОВЕР");
            StartCoroutine(GameOver());
        }
        //else if(!gameState.gameover)
        //{
        //     animator.SetTrigger("Go");
        //}
    }

    IEnumerator GameOver()
    {
        animator.SetTrigger("LookingAround");
        yield return new WaitForSeconds(1.4f);
        animator.SetTrigger("Idle");
    }
}
