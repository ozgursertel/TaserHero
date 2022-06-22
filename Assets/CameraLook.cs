using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public GameObject player;
    public float minimumX, maximumX, minimumY, maximumY;
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
        if (player.GetComponent<ScreenAim>().dragging)
        {
            if(player.GetComponent<ScreenAim>().enemy != null)
            {
                targetTrans = player.GetComponent<ScreenAim>().enemy.transform.parent.GetChild(0).transform;
            }
            
        }
        else
        {
            targetTrans = player.GetComponent<NearestEnemy>().getClosestEnemy();
        }

        
        

        transform.LookAt(targetTrans.position);
        Debug.Log(transform.position);
        float ry = transform.eulerAngles.y;
        if (ry >= 180) ry -= 360;
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(transform.eulerAngles.x, minimumX, maximumX),
            Mathf.Clamp(ry, minimumY, maximumY),
            0
        );
    }
}
