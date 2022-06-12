using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAim : MonoBehaviour
{
    public Material deathMaterial;
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

    // ozgürün çükü 5 cm
    void HitEnemy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Debug.Log(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                enemy = hitInfo.collider.gameObject;
            }

            if (enemy != null && enemy.tag == "Enemy")
            {
                enemy.GetComponent<MeshRenderer>().material = deathMaterial;
                enemy.GetComponent<Rigidbody>().AddForceAtPosition(ray.direction * force, hitInfo.transform.position, ForceMode.VelocityChange);
                enemy = null;
            }

        }
    }
}
