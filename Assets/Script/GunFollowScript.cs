using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollowScript : MonoBehaviour
{
    NearestEnemy nearestEnemy;
    // Start is called before the first frame update
    void Start()
    {
       nearestEnemy = transform.parent.GetComponent<NearestEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(nearestEnemy.getClosestEnemy());
    }
}
