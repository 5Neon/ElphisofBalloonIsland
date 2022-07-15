using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public GameObject[] CloudPrefabs;
    public Transform targetPosition;
    public Transform cloudAttachPosition;

    float randomPositionX;
    float randomPositionY;
    float randomPositionZ;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                randomPositionX = Random.Range(-100f, 100f);
                randomPositionY = Random.Range(-60f, -40f);
                randomPositionZ = Random.Range(-100f, 100f);

                Instantiate(CloudPrefabs[j], cloudAttachPosition.transform.position + new Vector3(randomPositionX, randomPositionY, randomPositionZ), CloudPrefabs[j].transform.rotation * Quaternion.Euler(/*Random.Range(-90f, 90f)*/transform.rotation.x, Random.Range(-90f, 90f), transform.rotation.x /*Random.Range(-90f, 90f)*/), cloudAttachPosition.transform);
            }
        }
    }
}
