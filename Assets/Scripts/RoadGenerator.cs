using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoadGenerator : MonoBehaviour
{
    public GameObject gameManager;
    GameState gameState;
    public GameObject RoadPrefab;
    public GameObject RoadEnemyPrefab;
    public GameObject RoadEnemyLeftPrefab;
    public GameObject RoadEnemyRightPrefab;
    List<GameObject> roads = new List<GameObject>();
    public float maxSpeed = 10;
    float speed = 0;
    public int maxRoadCount = 5;
    bool isStoped;
    int cycleEnemySpawn = 0;
    System.Random rnd = new System.Random();
    int rand = 0;
    void Start()
    {
        gameState = gameManager.GetComponent<GameState>();
        ResetLevel();
        //StartLevel();
    }
    void Update()
    {
        if (speed == 0) return;

        foreach (GameObject road in roads)
        {
            road.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }
        
        if (roads[0].transform.position.z < -15 && !gameState.gameover)
        {
            CreateNextRoad();

            Destroy(roads[0]);
            roads.RemoveAt(0);   
        }
        else if (gameState.gameover)
        {
            speed = 0;
        }
        //if (Input.GetKeyDown(KeyCode.Space)&& !isStoped)
        //{
        //    StartCoroutine(ResetLevelDeley());
        //}
    }
    //IEnumerator ResetLevelDeley()
    //{
    //    yield return new WaitForSeconds(1f);
    //    ResetLevel();
    //    isStoped = true;
    //}

    public void StartLevelWithDeley()
    {
        StartCoroutine(DeleyStart());
    }
    IEnumerator DeleyStart()
    {
        yield return new WaitForSeconds(2.4f);
        speed = maxSpeed;
        SwipeManager.instance.enabled = true;
    }

    public void ResetLevel()
    {
        //print("ResetLevel "+ gameState.gameover);
        gameState.gameover = false;
        //print("ResetLevel " + gameState.gameover);
        //SwipeManager.instance.enabled = false;
        speed = 0;
        while (roads.Count > 0)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);//Удалить из списка
        }
        for (int i = 0; i < maxRoadCount; i++)
        {
            CreateNextRoad();
        }
    }

    private void CreateNextRoad()
    {
        Vector3 position = Vector3.zero;
        if (roads.Count > 0) 
            position= roads[roads.Count-1].transform.position + new Vector3(0, 0, 15);
        GameObject newRoadEn = null, newRoad;
        if (cycleEnemySpawn == 3)
        {
            //Vector3 posDiff = position;
            //newRoadEn = Instantiate(RoadEnemyPrefab,
            //                        posDiff + new Vector3(rnd.Next(0, 3), 0, 0),
            //                        Quaternion.identity);
            rand = rnd.Next(-1, 1);
            //print("rnd.Next(-1, 1) ="+ rand);
            if (rand == 0)
            {
                newRoadEn = Instantiate(RoadEnemyPrefab, position, Quaternion.identity);
            }
            else if(rand > 0)
            {
                newRoadEn = Instantiate(RoadEnemyRightPrefab, position, Quaternion.identity);
            }
            else if(rand < 0)
            {
                newRoadEn = Instantiate(RoadEnemyLeftPrefab, position, Quaternion.identity);
            }
            newRoadEn.transform.SetParent(transform);
            roads.Add(newRoadEn);
            cycleEnemySpawn = 0;
            //print("cycleEnemySpawn " + cycleEnemySpawn);
        }
        else
        {
            newRoad = Instantiate(RoadPrefab, position, Quaternion.identity);
            newRoad.transform.SetParent(transform);
            roads.Add(newRoad);
        }   
        cycleEnemySpawn++;
    }
}

//cycleEnemySpawn++;
            
//            if(cycleEnemySpawn == 10)
//            {
//                print("cycleEnemySpawn "+cycleEnemySpawn);
//                print("enemies " + enemies.Count);
//                Destroy(enemies[0]);
//                enemies.RemoveAt(0);
//                GameObject newEnemy = Instantiate(EnemyPrefab, 
//                                                    roads[2].transform.position, 
//                                                    Quaternion.identity);
//                enemies.Add(newEnemy);
//                cycleEnemySpawn = 0;
                
//            }
