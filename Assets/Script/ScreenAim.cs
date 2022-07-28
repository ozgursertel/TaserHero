using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAim : MonoBehaviour
{

    public float force;
    [HideInInspector]
    public GameObject enemy;
    [HideInInspector] 
    public bool dragging;
    private float dist;
    private Vector3 offset;
    private Transform toDragRigidbodyTransform;
    EnemyScript enemyScript;
    private Rigidbody[] ragdoll;
    Transform toDrag;
    public _LineRenderer line;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameStarted)
        {
            return;
        }
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
                    enemyScript = enemy.transform.parent.GetComponent<EnemyScript>();
                    enemyScript.HitFromTaser(ray, force, hit);
                    toDragRigidbodyTransform = hit.transform.parent.GetChild(1).GetChild(0).GetComponent<Rigidbody>().transform;
                    toDrag = hit.transform.parent.GetChild(1);
                    dist = hit.transform.position.z - Camera.main.transform.position.z;
                    v3 = new Vector3(pos.x, pos.y, dist);
                    v3 = Camera.main.ScreenToWorldPoint(v3);
                    offset = toDragRigidbodyTransform.position - v3;
                    dragging = true;
                    ragdoll = toDrag.GetComponentsInChildren<Rigidbody>();
                    line.DrawLine(toDragRigidbodyTransform);
                }
            }
        }

        if(dragging && touch.phase == TouchPhase.Moved)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            foreach(Rigidbody r in ragdoll)
            {
                r.drag = 10;
            }
            toDragRigidbodyTransform.GetChild(0).GetChild(0).GetComponent<Rigidbody>().MovePosition(v3 + offset * Time.deltaTime);
            line.DrawLine(toDragRigidbodyTransform);

        }

        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            if(ragdoll != null)
            {
                foreach (Rigidbody r in ragdoll)
                {
                    r.drag = 0.1f;
                }
            }        
            dragging = false;
            line.EndLine();
            Debug.Log("SCREEN AIM:Touch Delta -X Position" + -touch.deltaPosition.x);
            toDragRigidbodyTransform.GetChild(0).GetChild(0).GetComponent<Rigidbody>().AddForce(new Vector3(-touch.deltaPosition.x*50,Input.mousePosition.y*10,0));

            if (enemyScript.health > 0)
            {
                StartCoroutine(enemyScript.GetUpEnemy());
            }
            else
            {
                enemyScript.Dead();
            }
           
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
