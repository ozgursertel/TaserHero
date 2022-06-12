using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Physics.CheckSphere(transform.position, radius, 1 << 6))
        {
            GetComponent<SplineFollower>().enabled = true;
        }
    }

}
    