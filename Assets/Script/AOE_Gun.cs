using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE_Gun : MonoBehaviour
{
    public float ExplosionRadius;
    public float ExplosionPower;
    private Vector3 spawnPos;
    public GameObject ExplosionEffect;

    private void Start()
    {

    }

    private void setDamageSwpawnPosition(Vector3 v)
    {
        spawnPos = new Vector3(v.x,v.y+2,v.z);
    }
    private Vector3 getDamageSpanwPosition()
    {
        //Camera Point to x and calculate y and z
        return spawnPos;
    }

    public void Update()
    {
        if (Input.touchCount != 1)
        {
            return;
        }
        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;
        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Ground")
                {
                    setDamageSwpawnPosition(hit.point);
                    Explosion();
                }
            }

        }
     }

    public void Explosion()
    {
        Vector3 spawnPos = getDamageSpanwPosition();
        GameObject.Instantiate(ExplosionEffect, spawnPos, Quaternion.identity);
        StartCoroutine(afterExplosion(spawnPos));

    }
    IEnumerator afterExplosion(Vector3 spawn)
    {
        yield return new WaitForSeconds(0.2f);
        Collider[] colliders = Physics.OverlapSphere(spawn, ExplosionRadius);
        foreach (Collider collider in colliders)
        {
                if (collider.TryGetComponent(out Rigidbody rigidbody))
                {
                    Vector3 direction = (collider.transform.position - spawn).normalized;
                    rigidbody.AddForce(direction * ExplosionPower, ForceMode.Impulse);
                }

                if (collider.gameObject.transform.parent.TryGetComponent(out EnemyScript enemyScript))
                {
                    enemyScript.Dead();
                }
            }
            yield return new WaitForSeconds(0.2f);

     }
}
