using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float radius;
    SplineFollower splineFollower;
    // Start is called before the first frame update
    void Start()
    {
        splineFollower = GetComponent<SplineFollower>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!Physics.CheckSphere(transform.position, radius, 1 << 6))
        {
            if(splineFollower != null)
            {
               splineFollower.enabled = true;

            }
        }
    }

   void MovingEnd()
    {
        Debug.Log("Move Ended");
        splineFollower.enabled = false;
        splineFollower.spline = GameObject.Find("Spline 1").GetComponent<SplineComputer>();
        splineFollower.Restart();
    }

}
    