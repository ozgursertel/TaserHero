using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraLook : MonoBehaviour
{
    private GameObject player;
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

        if (GameManager.Instance.isGameEnded)
        {
            return;
        }
        if (player.GetComponent<ScreenAim>().dragging)
        {
            //Burada Target Transı screen aimden çektiğimiz enemynin spinine eşitledim
            targetTrans=player.GetComponent<ScreenAim>().enemy.transform.parent.GetChild(1).GetChild(0).transform;
        }
        else
        {
            //Buradada getCloset Enemyde dönen değeri değiştirdim
            targetTrans=GetComponent<NearestEnemy>().getClosestEnemy();
        }
        if(targetTrans != null)
        {
            transform.DODynamicLookAt(targetTrans.position, 0.3f);
        }
        float ry = transform.eulerAngles.y;
        if (ry >= 180) ry -= 360;

        transform.eulerAngles = new Vector3(
            Mathf.Clamp(transform.eulerAngles.x, minimumX, maximumX),
            Mathf.Clamp(ry, minimumY, maximumY),
            0
        );
    }
}
