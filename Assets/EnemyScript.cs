using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Material deathMaterial;
    public bool isDead = false;
    public void HitFromTaser(Ray ray,float force,RaycastHit hitInfo)
    {
        if (!isDead)
        {
            GetComponent<MeshRenderer>().material = deathMaterial;
            GetComponent<Rigidbody>().AddForceAtPosition(ray.direction * force, hitInfo.transform.position, ForceMode.VelocityChange);
            isDead = true;
        }
    }
}
