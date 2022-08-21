using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTargetChanger : MonoBehaviour
{
    public Transform playerTarget;
    public Transform balloonTarget;

    void Start()
    {
        CamOnPlayerTarget();
        CamOnPlayerTarget();
        //GameObject.FindWithTag("BalloonTarget");
        //playerTarget = GameObject.FindWithTag("Player").transform.position;
        //balloonTarget = GameObject.FindWithTag("BalloonTarget").transform.position;
    }   


    public void CamOnPlayerTarget()
    {
        transform.position = new Vector3 (playerTarget.position.x, playerTarget.position.y, playerTarget.position.z);
    }

    public void CamOnBalloonTarget()
    {
        transform.position = new Vector3 (balloonTarget.position.x, balloonTarget.position.y, balloonTarget.position.z);
    }
}
