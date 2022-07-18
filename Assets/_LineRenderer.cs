using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _LineRenderer : MonoBehaviour
{
    public LineRenderer line;
    public Transform startPoint;
    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DrawLine(Transform target)
    {
        line.enabled = true;
        line.SetPosition(0, startPoint.position);
        line.SetPosition(1, target.position);
    }

    public void EndLine()
    {
        line.enabled = false;
    }


}
