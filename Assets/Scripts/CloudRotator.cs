using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRotator : MonoBehaviour
{
    public Transform targetPosition;
    public float rotateSpeed = 0.005f;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * rotateSpeed);
    }
}
