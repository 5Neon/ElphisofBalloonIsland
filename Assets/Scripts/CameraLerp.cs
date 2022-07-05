using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    [Header("Target")]
    public Transform CameraTarget;
    [Space(10)]

    [Header("Rotation Speed Setting")]
    public float pLerp = 0.08f;
    public float rLerp = 0.1f;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, CameraTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, CameraTarget.rotation, rLerp);
    }
}