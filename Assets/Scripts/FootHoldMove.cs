using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootHoldMove : MonoBehaviour
{
    float minmaxpos = 2f;
    Vector3 position;

    private void Start()
    {
        position = transform.localPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.transform.CompareTag("Player"))
    //    {
    //        collision.transform.SetParent(transform);
    //    }
    //}

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void FixedUpdate()
    {
        Vector3 vec = position;
        vec.x += minmaxpos * Mathf.Sin(Time.time * 1f);
        transform.localPosition = vec;
        Debug.Log(vec);
    }
}
