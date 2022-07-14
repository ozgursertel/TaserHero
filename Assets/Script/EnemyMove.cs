using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float RotationAmount = 2f;
    public int TicksPerSecond = 60;
    public bool Pause = false;

    private void Start()
    {
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        WaitForSeconds Wait = new WaitForSeconds(1f / TicksPerSecond);

        while (true)
        {
            if (!Pause)
            {
                transform.Translate(Vector3.right * RotationAmount);
            }

            yield return Wait;
        }
    }
}
