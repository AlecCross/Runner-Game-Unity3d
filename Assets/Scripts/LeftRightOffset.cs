using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightOffset : MonoBehaviour
{
    Vector3 targetPos;
    float laneOffset = 1f;
    float laneChangeSpeed = 15;
    private void Start()
    {
        StartCoroutine(OffsetMove());
    }
    IEnumerator OffsetMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < 3; i++)
            {
                targetPos = new Vector3(targetPos.x - laneOffset,
                                   transform.position.y,
                                   transform.position.z);
                //print(gameObject.name + "Смещение влево");
                yield return new WaitForSeconds(1f);
                ChangePosition();
            }
            for (int i = 0; i < 5; i++)
            {
                targetPos = new Vector3(targetPos.x + laneOffset,
                           transform.position.y,
                           transform.position.z);
                //print(gameObject.name + "Смещение вправо");
                yield return new WaitForSeconds(1f);
                ChangePosition();
            }
        }
    }

    void ChangePosition()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                            targetPos,
                                            laneChangeSpeed * Time.deltaTime);
        //print(gameObject.name + "Смещение подтверждение");
    }
}
   



