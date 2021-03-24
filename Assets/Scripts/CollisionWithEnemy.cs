using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionWithEnemy : MonoBehaviour
{
    [SerializeField]
    int health;
    [SerializeField]
    int maxHealth;
    public Text healthBar;
    public GameObject gameManager;
    GameState gameState;
    public Animator playerAnimator;
    int scoreCount;
    public Text scoreDisplay;
    public void AddScore(int score)
    {
        scoreCount += score;
    }

    private void Start()
    {
        health = maxHealth;
        scoreCount = 0;
        gameState = gameManager.GetComponent<GameState>();
        //gameMaster = GameObject.Find("GameManager");
    }
    private void Update()
    {
        if (health > 0 && !gameState.gameover)
        {
            healthBar.text = "Lives: " + health;
            //print("не Потрачено!");
        }
        else if (health <= 0 && !gameState.gameover)
        {
            print("Потрачено!");
            healthBar.text = "GameOver";
            gameState.gameover = true;
            health = maxHealth;
        }
        if (scoreCount == 50)
        {
            if(HiScore.hiScore < scoreCount)
            {
                HiScore.hiScore = scoreCount;
            }
            SceneManager.LoadScene("VictoryScene");
        }
        //print("gameState.gameover " + gameState.gameover.ToString());

        scoreDisplay.text = "Score:" + scoreCount;
        //print("Score: " + scoreCount);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ch43_nonPBR" && health > 0)
        {
            health--;
            playerAnimator.SetTrigger("HitOnLeftOfHead");
            print("Столкновение " + gameObject.name + "теряет жизни " + health);
        }
        //else if (collision.gameObject.name == "Ch43_nonPBR" && health > 0)
        //{
        //    if (collision.gameObject.name == "Road" && health > 0)
        //    {
        //        //playerAnimator.SetTrigger("HitOnLeftOfHead");
        //        scoreCount += scoreCount;
        //        print("Столкновение " + gameObject.name + "начислены очки " + scoreCount);
        //    }
        //}
        if (collision.gameObject.name == "Plane" && health > 0)
        {
            //playerAnimator.SetTrigger("HitOnLeftOfHead");
            scoreCount += 10;
            print("Столкновение " + gameObject.name + "начислены очки " + scoreCount);
        }

    }
}
