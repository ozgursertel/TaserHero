using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Material deathMaterial;
    public Rigidbody spineRb;
    public Animator animator;
    public SkinnedMeshRenderer skinnedMesh;
    public bool isDead = false;
    public void HitFromTaser(Ray ray,float force,RaycastHit hitInfo)
    {
        Debug.Log("Hited");
        if (!isDead)
        {
            skinnedMesh.material = deathMaterial;
            animator.enabled = false;
            spineRb.AddForceAtPosition(ray.direction * force, hitInfo.transform.position, ForceMode.VelocityChange);
            gameObject.transform.GetChild(0).gameObject.layer = 7;
            isDead = true;
        }
    }
}
