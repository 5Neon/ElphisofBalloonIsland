using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFollower : MonoBehaviour
{
    public Transform Point;

    void Update()
    {
        transform.position = new Vector3(Point.position.x, Point.position.y, Point.position.z);
    }
}