using UnityEngine;
using System.Collections;
//using UnityStandardAssets.Vehicles.Car;

public class Controller : MonoBehaviour
{
    private bool inBalloon = false;
    //PlayerMovement playerScript;
    BalloonMovement balloonScript;
    GameObject player;
    GameObject dummyPlayer;

    void Start()
    {
        balloonScript = GetComponent<BalloonMovement>();
        player = GameObject.FindWithTag("Player");
        dummyPlayer = GameObject.FindWithTag("DummyPlayer");
        dummyPlayer.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inBalloon == false)
        {
            if (Input.GetKey(KeyCode.E))
            {
                inBalloon = true;
                player.transform.parent = gameObject.transform;
                balloonScript.enabled = true;
                player.SetActive(false);
                dummyPlayer.SetActive(true);
                Debug.Log("Enter");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //탑승 아이콘 탑재
        }
    }

    void Update()
    {
        if (inBalloon == true && Input.GetKey(KeyCode.F))
        {
            balloonScript.enabled = false;
            player.SetActive(true);
            dummyPlayer.SetActive(false);
            player.transform.parent = null;
            inBalloon = false;
        }
    }
}