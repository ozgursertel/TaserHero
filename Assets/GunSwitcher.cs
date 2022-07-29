using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSwitcher : MonoBehaviour
{
    public ScreenAim holdAndDragGun;
    public AOE_Gun aoeGun;
    public OneHit_Gun oneHitGun;

    public GameObject yellowGun;
    public GameObject blueGun;
    public GameObject purpleGun;


    private void Start()
    {
        OpenYellowGun();
    }

    public void OpenBlueGun()
    {
        holdAndDragGun.enabled = false;
        oneHitGun.enabled = false;
        aoeGun.enabled = true;
        StartCoroutine(yellowGun.GetComponent<GunChangeScript>().GunChange());
        StartCoroutine(blueGun.GetComponent<GunChangeScript>().BringGun());
        StartCoroutine(purpleGun.GetComponent<GunChangeScript>().GunChange());
    }

    public void OpenPurpleGun()
    {
        holdAndDragGun.enabled = false;
        oneHitGun.enabled = true;
        aoeGun.enabled = false;
        StartCoroutine(yellowGun.GetComponent<GunChangeScript>().GunChange());
        StartCoroutine(blueGun.GetComponent<GunChangeScript>().GunChange());
        StartCoroutine(purpleGun.GetComponent<GunChangeScript>().BringGun());
    }

    public void OpenYellowGun()
    {
        holdAndDragGun.enabled = true;
        oneHitGun.enabled = false;
        aoeGun.enabled = false;
        StartCoroutine(yellowGun.GetComponent<GunChangeScript>().BringGun());
        StartCoroutine(blueGun.GetComponent<GunChangeScript>().GunChange());
        StartCoroutine(purpleGun.GetComponent<GunChangeScript>().GunChange());
    }
}
