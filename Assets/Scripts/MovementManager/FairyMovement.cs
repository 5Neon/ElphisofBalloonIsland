using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMovement : MonoBehaviour
{
  
    public GameObject Player;

    public float RotatePower = 50;

    void Update()
    {  
        //float RandomValue = Random.Range(0,100);

        Vector3 PlayerPosition = Player.transform.position;

        transform.RotateAround(PlayerPosition, Vector3.up, RotatePower*Time.deltaTime);
    }
}