using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionWithEnemy : MonoBehaviour
{
    [SerializeField]
    int health;

    private void Start()
    {
        health = 10;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ch43_nonPBR" && health > 0)
        {
            health--;
            print("Столкновение " + gameObject.name + "теряет жизни " + health);
        }
    }
}
