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
    private bool destinationSetted = false;
    [SerializeField]
    private float getUpTimer;
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    public float radius;
    public float playerDeadRadius;
    private bool setWalkingAnimations;
    //Pelferer
    //x = 2.34452 y = 1.638067 z = 2.444697

    //Stickman
    //x = 0.02350442 y = 0.008783284 z = 0.02287093;
    private void Start()
    {
        FlagParticle(false);
        setWalkingAnimations = false;
    }
    public void HitFromTaser(Ray ray,float force,RaycastHit hitInfo)
    {
        if (!isHitted)
        {
            animator.enabled = false;
            spineRb.AddForceAtPosition(ray.direction * force, hitInfo.transform.position, ForceMode.VelocityChange);
            health = health - GameObject.Find("Player").GetComponent<PlayerScript>().hitDamage;
            if(transform.GetChild(0).name == "Pilferer")
            {
                transform.GetChild(0).GetComponent<BoxCollider>().size = new Vector3(0.1f, 0.1f, 0.1f);
            }
            if(transform.GetChild(0).name == "Stickman")
            {
                transform.GetChild(0).GetComponent<BoxCollider>().size = new Vector3(0.001f, 0.001f, 0.001f);
            }
            FlagParticle(true);
            isHitted = true;
            navMeshAgent.enabled = false;
        }
    }

    public void Dead()
    {
        animator.enabled = false;
        gameObject.transform.GetChild(0).gameObject.layer = 7;
        this.gameObject.tag = "DeadEnemy";
        GameObject.Find("Player").SendMessage("RemoveEnemy",this.gameObject);
        transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        navMeshAgent.enabled = false;
        isDead = true;
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
            if (transform.GetChild(0).name == "Pilferer")
            {
                transform.GetChild(0).GetComponent<BoxCollider>().size = new Vector3(2.34452f, 1.638067f, 2.444697f);

            }
            if (transform.GetChild(0).name == "Stickman")
            {
                transform.GetChild(0).GetComponent<BoxCollider>().size = new Vector3(0.02350442f, 0.008783284f, 0.02287093f);
            }

            this.transform.position = new Vector3(spineRb.transform.position.x, spineRb.transform.position.y-0.3f, spineRb.transform.position.z);
            FlagParticle(false);
            animator.enabled = true;
            navMeshAgent.enabled = true;

        }
    }

    private void Update()
    {
        if (!GameManager.Instance.isGameStarted)
        {
            return;
        }
        if(isHitted || isDead)
        {
            return;
        }
        if (GameManager.Instance.isGameEnded)
        {
            navMeshAgent.enabled = false;
            return;
        }
        if (!setWalkingAnimations)
        {
            animator.SetTrigger("GameStarted");
            setWalkingAnimations = true;
        }
        if (Physics.CheckSphere(transform.position, radius, 1 << 8) && !isHitted && !isDead && !destinationSetted)
        {
            navMeshAgent.SetDestination(GameObject.Find("Player").transform.position);
            destinationSetted = true;
        }
        else
        {
            //navMeshAgent.SetDestination(this.transform.position);
        }

        if (Physics.CheckSphere(transform.position, playerDeadRadius, 1 << 8) && !isHitted && !isDead)
        {
            if (GameManager.Instance.isGameEnded)
            {
                return;
            }
                animator.SetTrigger("Kick");
                Debug.Log("Kicked");
                GameManager.Instance.LevelFailed();
        }

        if (Physics.CheckSphere(transform.position, 8, 1 << 9))
        {
            if (!isDead)
            {
                Debug.Log("Enemy Dead By Falling");
                Dead();
            }
            
        }
    }

 
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.isGameEnded)
        {
            return;
        }
        if (other.gameObject.tag == "Player")
        {
            animator.SetTrigger("Kick");
            Debug.Log("Kicked");
            GameManager.Instance.LevelFailed();
        }
        if (other.gameObject.tag == "DeadZone")
        {
           
        }
    }
}
