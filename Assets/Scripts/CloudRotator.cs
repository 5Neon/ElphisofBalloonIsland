using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRotator : MonoBehaviour
{
    public float rotateSpeed = 0.001f;

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed);
    }
}
