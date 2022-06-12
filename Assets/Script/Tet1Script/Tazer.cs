using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tazer : MonoBehaviour
{
    public Transform bulletSpawnPosition;
    public GameObject bulletPrefab;
    public float bulletSpeed;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPosition.up * bulletSpeed;
        }    
    }



}
