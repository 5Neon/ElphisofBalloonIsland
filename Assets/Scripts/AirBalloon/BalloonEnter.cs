using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonEnter  : MonoBehaviour
{
    private bool inBalloon = false;
    private bool inPort = false;
    
    public GameObject player;

    GameObject dummyPlayer;
    GameObject portArea;
    GameObject target;

    private CamTargetChanger CamTargetChanger;

    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        dummyPlayer = GameObject.FindWithTag("DummyPlayer");
        portArea = GameObject.FindWithTag("PortArea");
        target = GameObject.FindWithTag("Target");

        dummyPlayer.SetActive(false);

        CamTargetChanger = target.GetComponent<CamTargetChanger>();
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "PortArea")
        {
            inPort = true;
            //Debug.Log("InPortCheck");
        }

        if (other.gameObject.tag == "Player" && inPort == true)
        {
            //Debug.Log("PlayerCheck");
            if (inBalloon == false && Input.GetKey(KeyCode.F))
            {
                //Debug.Log("IN");

                player.transform.parent = gameObject.transform;

                player.SetActive(false);
                dummyPlayer.SetActive(true);

                GameObject.FindWithTag("AirBalloonTarget").GetComponent<BalloonMovement>().enabled = true;
                
                //탑승아이콘활성화
                Invoke("InBalloonFtoT", 0.1f);
                return;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PortArea")
        {
            inPort = false;

            //탑승 아이콘 비활성화
        }
    }

    void Update()
    {
        if(inBalloon == true)
        {
            //Debug.Log("InBalloonCheck");
            CamTargetChanger.CamOnBalloonTarget();

            if (inPort == true && Input.GetKey(KeyCode.F))
            {
                //Debug.Log("OUT");

                player.transform.parent = null;

                player.SetActive(true);
                dummyPlayer.SetActive(false);
                
                GameObject.FindWithTag("AirBalloonTarget").GetComponent<BalloonMovement>().enabled = false;

                Invoke("InBalloonTtoF", 0.1f);
                return;
            }
        }

        else if(inBalloon == false)
        {
            //Debug.Log("OutBalloonCheck");
            CamTargetChanger.CamOnPlayerTarget();
            return;
        }
        
    }

    void InBalloonFtoT()
    {
        
        if(inBalloon == false)
        {
            inBalloon = true;
            return;
        }
    }

    void InBalloonTtoF()
    {
        if (inBalloon == true)
        {
            inBalloon = false;
            return;
        }
    }
}