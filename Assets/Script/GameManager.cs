using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Material deathMaterial;
    public float force;
    Rigidbody rig;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
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
                rig = hitInfo.collider.GetComponent<Rigidbody>();
            }

            if (rig != null)
            {
                rig.GetComponent<MeshRenderer>().material = deathMaterial;
                rig.AddForceAtPosition(ray.direction * force, hitInfo.transform.position, ForceMode.VelocityChange);
            }

        }
    }
}
