using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    Rigidbody movingEnemyBRig;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        movingEnemyBRig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movingEnemyBRig.velocity = -transform.forward * speed;
        
    }
}
