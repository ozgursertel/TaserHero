using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmooth : MonoBehaviour
{
    public Transform Enemy;
    public float Speed = 1f;

    private Coroutine LookCoroutine;


    public void Update()
    {
        StartRotating();
        LookAt();
    }

    public void StartRotating()
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt());
    }

    public IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(Enemy.position - transform.position);

        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * Speed;

            yield return null;
        }


    }


    // You can remove this, it is only for the demo.
    //private void OnGUI()
    //{
    //    if (GUI.Button(new Rect(10, 10, 200, 30), "Look At"))
    //    {
    //        StartRotating();
    //    }
    //}
}
