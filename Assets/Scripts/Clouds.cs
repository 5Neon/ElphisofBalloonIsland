using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public GameObject[] CloudPrefabs;
    public Transform playerPosition;
    public Transform CloudAttachPosition;

    float randomPositionX;
    float randomPositionY;
    float randomPositionZ;

    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                randomPositionX = Random.Range(-100f, 100f);
                randomPositionY = Random.Range(-40f, -20f);
                randomPositionZ = Random.Range(-100f, 100f);

                Instantiate(CloudPrefabs[j], CloudAttachPosition.transform.position + new Vector3(randomPositionX, randomPositionY, randomPositionZ), CloudPrefabs[i].transform.rotation * Quaternion.Euler(transform.rotation.x, Random.Range(-90f, 90f), transform.rotation.z), CloudAttachPosition.transform);
            }
        }
    }
}
