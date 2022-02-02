using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public ScoopToppings scoopToppings;
    public Stack stack;

    public Transform camTarget;

    public float smoothSpeed = 1f;
    public Vector3 offset;
    public float offsetZ;

    public bool camMoved = false;

    private void Start()
    {
        offset = new Vector3(0, 12f, offsetZ);
    }

    void Update()
    {
        //Vector3 smoothedPosition = transform.position;
        //Vector3 desiredPosition = camTarget.position + (offset - new Vector3(0, 0, stack.camDistanceZ));
        //smoothedPosition.y = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed).y;

        //transform.position = smoothedPosition;

        //Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + (Time.deltaTime * 15));

        if (scoopToppings.isEnd == false && camMoved == false)
        {
            Vector3 smoothedPosition = transform.position;
            /////////////offset.z = offset.z - stack.camDistanceZ;
            
            Vector3 desiredPosition = camTarget.position + offset; /*(offset - new Vector3(0, 0, stack.camDistanceZ));*/
            smoothedPosition.x = 0;
            smoothedPosition.y = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed).y;
            /////////////////smoothedPosition.z = Vector3.Lerp(transform.position, new Vector3(0, 0, stack.camDistanceZ), smoothSpeed).z;
            smoothedPosition.z = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed).z;

            //transform.position = smoothedPosition;
            ///////////////////transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z + (Time.deltaTime * 15));
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, smoothedPosition.z);
        }
        if (scoopToppings.isEnd == true && camMoved == false)
        {
            Vector3 smoothedPosition1 = transform.position;
            Vector3 desiredPosition1 = camTarget.position + offset;
            smoothedPosition1.y = Vector3.Lerp(transform.position, desiredPosition1, smoothSpeed).y;
            smoothedPosition1.x = Vector3.Lerp(transform.position, desiredPosition1, smoothSpeed).x;
            smoothedPosition1.z = Vector3.Lerp(transform.position, desiredPosition1, smoothSpeed).z;

            transform.position = smoothedPosition1;
            //camMoved = true;
        }

        //transform.LookAt(camTarget);
    }

    public IEnumerator camWait()
    {
        yield return new WaitForSeconds(2f);
        camMoved = true;
    }
}
