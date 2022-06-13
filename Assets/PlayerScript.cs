using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerScript : MonoBehaviour
{
    private GameObject[] playerPositions;
    private int positionCounter = 0;
    private bool checkEnemy;

    public float positionChangeTime;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        playerPositions = FindObsWithTag("PlayerPosition");
        checkEnemy = true;
        foreach(GameObject obj in playerPositions)
        {
            Debug.Log("Player Position pos" + obj.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!Physics.CheckSphere(transform.position, radius, 1 << 6) && checkEnemy)
        {
            checkEnemy = false;
            positionCounter++;
            if(positionCounter < playerPositions.Length)
            {
                StartCoroutine(MoveNextPosition(playerPositions[positionCounter].transform.position));
            }
            else
            {
                Debug.Log("Level Ended");
            }
        }

    }

    IEnumerator MoveNextPosition(Vector3 playerPos)
    {
        Debug.Log("Moving Position");
        transform.DOMove(playerPositions[positionCounter].transform.position, positionChangeTime);
        transform.DORotate(playerPositions[positionCounter].transform.rotation.eulerAngles, positionChangeTime);
        yield return new WaitForSeconds(positionChangeTime);
        checkEnemy = true;
    }

    GameObject[] FindObsWithTag(string tag)
    {
        GameObject[] foundObs = GameObject.FindGameObjectsWithTag(tag);
        Array.Sort(foundObs, CompareObNames);
        return foundObs;
    }

    int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }

}
    