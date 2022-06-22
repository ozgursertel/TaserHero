using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public GameObject player;

    Vector3 followPosition;
    private Transform targetTrans;
    private float desiredDuration = 3f;
    private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float completePersentage = elapsedTime / desiredDuration;


        targetTrans = player.GetComponent<NearestEnemy>().getClosestEnemy();


        Vector3 startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        followPosition = new Vector3(targetTrans.position.x, targetTrans.position.y, targetTrans.position.z);
        //transform.LookAt(enemyTarget.transform);
        

        transform.LookAt(followPosition);
        Vector3 endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(startPosition, endPosition, completePersentage);

        
    }
}
