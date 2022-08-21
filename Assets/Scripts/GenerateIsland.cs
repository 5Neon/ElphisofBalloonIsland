using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateIsland : MonoBehaviour
{
    public GameObject[] IslandList;
    private GameObject clone;
    public Transform GeneratePosition;

    public float waitTime = 3f;
    int i = 0;

    void Start()
    {
        transform.position = GeneratePosition.position;

        StartCoroutine(ChangeIsland());
    }

    void FixedUpdate()
    {
        GeneratePosition.transform.Rotate(Vector3.up * 0.5f);
    }

    IEnumerator ChangeIsland()
    {
        clone = Instantiate(IslandList[i], transform.position, transform.rotation, GeneratePosition.transform);
        Destroy(clone, waitTime);

        yield return new WaitForSeconds(waitTime);

        if (i == 4) i = 0;
        else i++;

        StartCoroutine(ChangeIsland());
    }
}
