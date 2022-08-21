using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyLerpFollower : MonoBehaviour
{
    public Transform fairyTarget;

    public float pLerp = 0.01f;
    public float rLerp = 0.01f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, fairyTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, fairyTarget.rotation, rLerp);
    }
}