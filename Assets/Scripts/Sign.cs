using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject dialoguemanager;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Debug.Log("충돌 감지");
            dialoguemanager.GetComponent<DialogueManager>().Event_1_Sing();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // Debug.Log("충돌 감지 해제");
            dialoguemanager.GetComponent<DialogueManager>().Event_1_Sing_Out();
        }
    }
}
