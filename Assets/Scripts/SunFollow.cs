using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;

    private Coroutine LookCoroutine;

    public void Update()
    {
        StartRotation();
    }

    public void StartRotation()
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }
        LookCoroutine = StartCoroutine(LookAt());
    }

    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);

        float time = 0;

        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * speed;

            yield return null;
        }
    }
}
