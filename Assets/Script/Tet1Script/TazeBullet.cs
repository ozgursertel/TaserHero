using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TazeBullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);    
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(col.gameObject);
        Destroy(gameObject);
    }
}
