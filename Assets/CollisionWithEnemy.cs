using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithEnemy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ch43_nonPBR")
        {
            print("Столкновение игро теряет жизни");
        }
    }
}
