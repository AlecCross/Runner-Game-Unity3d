using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject RoadPrefab;
    List<GameObject> roads = new List<GameObject>();
    public float maxSpeed = 10;
    float speed = 0;
    public int maxRoadCount = 5;
    void Start()
    {
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
        if(roads[0].transform.position.z < -15)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);

            CreateNextRoad();
        }
    }

    public void StartLevel()
    {
        speed = maxSpeed;
        SwipeManager.instance.enabled = true;
    }

    public void ResetLevel()
    {
        SwipeManager.instance.enabled = false;
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
        GameObject newRoad = Instantiate(RoadPrefab, position, Quaternion.identity);
        newRoad.transform.SetParent(transform);
        roads.Add(newRoad);
    }
}
