using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody spineRb;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject stunnedParticle;
    public float health;
    public bool isDead = false;
    public bool isHitted = false;
    [SerializeField]
    private float getUpTimer;
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    public float radius;
    private void Start()
    {
        FlagParticle(false);
    }
    public void HitFromTaser(Ray ray,float force,RaycastHit hitInfo)
    {
        Debug.Log("Hited");
        if (!isHitted)
        {
            animator.enabled = false;
            spineRb.AddForceAtPosition(ray.direction * force, hitInfo.transform.position, ForceMode.VelocityChange);
            health = health - GameObject.Find("Player").GetComponent<PlayerScript>().hitDamage;
            //transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
            FlagParticle(true);
            isHitted = true;
            if(health <= 0)
            {
                isDead = true;
                Dead();
            }
        }
    }

    private void Dead()
    {
        gameObject.transform.GetChild(0).gameObject.layer = 7;
        this.gameObject.tag = "Dead Enemy";
        //skinnedMesh.material = deathMaterial;
    }

    public void FlagParticle(bool b)
    {
        if (b)
        {
            stunnedParticle.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            stunnedParticle.GetComponent<ParticleSystem>().Stop();
        }
    }

    public IEnumerator GetUpEnemy()
    {
        if (!isDead)
        {
            isHitted = false;
            yield return new WaitForSeconds(getUpTimer);
            //transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
            this.transform.position = new Vector3(spineRb.transform.position.x, spineRb.transform.position.y-0.3f, spineRb.transform.position.z);
            FlagParticle(false);
            animator.enabled = true;
        }
    }

    private void Update()
    {
        if (Physics.CheckSphere(transform.position, radius, 1 << 8) && !isHitted && !isDead)
        {
            Debug.Log("Player Found");
            navMeshAgent.SetDestination(GameObject.Find("Player").transform.position);
        }
        else
        {
            navMeshAgent.SetDestination(this.transform.position);
        }
    }
}
