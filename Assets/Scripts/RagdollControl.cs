using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    public Animator animator;
    public Rigidbody[] AllRigidbodies;
    public void Awake()
    {
        for (int i = 0; i < AllRigidbodies.Length; i++)
        {
            AllRigidbodies[i].isKinematic = true;
        }
    }
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        MakePhysical();
    //        StartCoroutine(ResetKinematic());
    //    }
    //}
    //private void MakePhysical()
    //{
    //    animator.enabled = false;
    //    for (int i = 0; i < AllRigidbodies.Length; i++)
    //    {
    //        AllRigidbodies[i].isKinematic = false;
    //    }
    //}
    //IEnumerator ResetKinematic()
    //{
    //    yield return new WaitForSeconds(2f);
    //    animator.enabled = true;
    //    for (int i = 0; i < AllRigidbodies.Length; i++)
    //    {
    //        AllRigidbodies[i].isKinematic = true;
    //    }
    //}
}
