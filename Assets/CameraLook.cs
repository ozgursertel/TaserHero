using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public GameObject player;
    
    Vector3 followPosition;
    private Transform targetTrans;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        targetTrans = player.GetComponent<NearestEnemy>().getClosestEnemy();

        followPosition = new Vector3(targetTrans.position.x, targetTrans.position.y, targetTrans.position.z);
        //transform.LookAt(enemyTarget.transform);

        transform.LookAt(followPosition);
    }
}
