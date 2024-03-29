using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestEnemy : MonoBehaviour
{
    public static NearestEnemy Instance;
    private GameObject[] multipleEnemies;
    public Transform closestEnemy;
    public bool enemyContact;
    //public Material detectedMaterial;


    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
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
        //closestEnemy.gameObject.GetComponent<MeshRenderer>().material = detectedMaterial;
    }

    public Transform getClosestEnemy()
    {
        //EnemyObject olarak tagı güncelledim 2 Enemy tagi karışmaması için
        multipleEnemies = GameObject.FindGameObjectsWithTag("EnemyObject");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach(GameObject goEnemies in multipleEnemies)
        {
            float currentDistance = Vector3.Distance(transform.position, goEnemies.transform.position);
            if(currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                //Burada goEnemies içerisinden spine ı bulup onu return ettim
                trans = goEnemies.transform;
            }

        }
        return trans;
    }

    public void RemoveEnemy(GameObject gameObject)
    {
        Debug.Log("Remove Enemy");
        List<GameObject> gameObjects = new List<GameObject>();
        gameObjects.AddRange(multipleEnemies);
        if (gameObjects.Contains(gameObject))
        {
            gameObjects.Remove(gameObject);
        }
        multipleEnemies = gameObjects.ToArray();
    }
}
