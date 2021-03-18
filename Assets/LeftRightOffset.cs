using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightOffset : MonoBehaviour
{
    Vector3 targetPos;
    float laneOffset = 1f;
    float laneChangeSpeed = 15;
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
                yield return new WaitForSeconds(1f);
                ChangePosition();
            }
            for (int i = 0; i < 5; i++)
            {
                targetPos = new Vector3(targetPos.x + laneOffset,
                           transform.position.y,
                           transform.position.z);
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
    }
}
   



