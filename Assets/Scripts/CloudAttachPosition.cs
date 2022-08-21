using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAttachPosition : MonoBehaviour
{
    public Transform target;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), 0.05f);
    }
}
