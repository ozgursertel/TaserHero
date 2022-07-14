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
    public float hitDamage;
    // Start is called before the first frame update
    void Start()
    {
        playerPositions = FindObsWithTag("PlayerPosition");
        checkEnemy = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameStarted)
        {
            return;
        }
        if(!Physics.CheckSphere(transform.position, radius, 1 << 6) && checkEnemy && !GetComponent<ScreenAim>().dragging)
        {
            checkEnemy = false;
            positionCounter++;
            if(positionCounter < playerPositions.Length)
            {
                StartCoroutine(MoveNextPosition(playerPositions[positionCounter].transform.position));
            }
            else
            {
                GameManager.Instance.LevelComplated();
            }
        }

    }

    IEnumerator MoveNextPosition(Vector3 playerPos)
    {
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
    