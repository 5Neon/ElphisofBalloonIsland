using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpFollower : MonoBehaviour
{
    public Transform LerpTarget;
    public float pLerp = 0.08f;
    public float rLerp = 0.1f;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, LerpTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, LerpTarget.rotation, rLerp);
    }
}