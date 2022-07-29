using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHit_Gun : MonoBehaviour
{
    public float power;
    public _LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        
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
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    StartCoroutine(OneHit(hit.collider.gameObject));
                }
            }

        }
    }

    private IEnumerator OneHit(GameObject obj)
    {
        obj.transform.parent.GetComponent<EnemyScript>().Dead();
        obj.transform.parent.GetChild(1).GetChild(0).GetComponent<Rigidbody>().AddForce(Vector3.forward * power, ForceMode.Impulse);
        line.DrawLine(obj.transform.parent.GetChild(1).GetChild(0));
        yield return new WaitForSeconds(0.5f);
    }
}
