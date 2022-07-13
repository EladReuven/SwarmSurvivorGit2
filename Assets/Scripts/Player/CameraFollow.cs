using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;

    public float smoothSpeed = 0.125f;

    private void FixedUpdate()
    {
        Vector3 smoothedPos = Vector3.Lerp(transform.position, followTarget.position, smoothSpeed);
        transform.position = smoothedPos;
    }
}
