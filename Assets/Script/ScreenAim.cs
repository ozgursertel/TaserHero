using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAim : MonoBehaviour
{

    public float force;
    GameObject enemy;
    private bool dragging;
    private float dist;
    private Vector3 offset;
    private Transform toDrag;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 v3;
        if(Input.touchCount != 1)
        {
            dragging = false;
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;


        if(touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    enemy = hit.collider.gameObject;
                    enemy.GetComponent<EnemyScript>().HitFromTaser(ray, force, hit);
                    toDrag = hit.transform;
                    dist = hit.transform.position.z - Camera.main.transform.position.z;
                    v3 = new Vector3(pos.x, pos.y, dist);
                    v3 = Camera.main.ScreenToWorldPoint(v3);
                    offset = toDrag.position - v3;
                    dragging = true;

                }
            }
        }

        if(dragging && touch.phase == TouchPhase.Moved)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            toDrag.position = v3 + offset;
        }

        if(dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            dragging = false;
           

        }
    }

    void HitEnemy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Enemy")
                {
                    enemy = hitInfo.collider.gameObject;
                }
              
            }

            if (enemy != null)
            {
                enemy.transform.parent.GetComponent<EnemyScript>().HitFromTaser(ray, force, hitInfo);
                enemy = null;
            }

        }
    }
}
