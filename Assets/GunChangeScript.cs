using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunChangeScript : MonoBehaviour
{
    public IEnumerator GunChange()
    {
        this.transform.DOLocalMove(new Vector3(0,0,-4),0.5f);
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);
    }

    public IEnumerator BringGun()
    {
        this.transform.position = new Vector3(0, 0, -4);
        this.transform.DOLocalMove(new Vector3(-0.031f, 0, -2), 0.5f);
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(true);
    }
}
