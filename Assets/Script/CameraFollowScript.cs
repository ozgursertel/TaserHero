using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 1, -6);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;

        transform.rotation = target.rotation;
    }
}
