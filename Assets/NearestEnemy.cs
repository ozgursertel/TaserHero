using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestEnemy : MonoBehaviour
{
    private GameObject[] multipleEnemies;
    public Transform closestEnemy;
    public bool enemyContact;
    public Material detectedMaterial;

    // Start is called before the first frame update
    void Start()
    {
        closestEnemy = null;
        enemyContact = false;
    }

    // Update is called once per frame
    void Update()
    {
        closestEnemy = getClosestEnemy();
        closestEnemy.gameObject.GetComponent<MeshRenderer>().material = detectedMaterial;
    }

    public Transform getClosestEnemy()
    {
        multipleEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach(GameObject goEnemies in multipleEnemies)
        {
            float currentDistance = Vector3.Distance(transform.position, goEnemies.transform.position);
            if(currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = goEnemies.transform;
            }

        }
        return trans;
    }
}
