using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAim : MonoBehaviour
{

    public float force;
    GameObject enemy;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HitEnemy();
    }

    void HitEnemy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Debug.Log(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Enemy")
                {
                    enemy = hitInfo.collider.gameObject;
                }
              
            }

            if (enemy != null)
            {
                enemy.GetComponent<EnemyScript>().HitFromTaser(ray, force, hitInfo);
                enemy = null;
            }

        }
    }
}
