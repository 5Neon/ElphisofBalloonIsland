using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpinner : MonoBehaviour
{
    public GameObject Player;
    public Transform target;

    public int RotateAngle = 45;

    void Update()
    {
        transform.position = target.position;
        Vector3 PlayerPosition = Player.transform.position;

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.RotateAround(PlayerPosition, Vector3.up, -RotateAngle);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.RotateAround(PlayerPosition, Vector3.up, RotateAngle);
        }

        transform.LookAt(PlayerPosition);
    }
}