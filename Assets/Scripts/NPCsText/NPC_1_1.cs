using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_1_1 : MonoBehaviour
{
    public GameObject dialoguemanager;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dialoguemanager.GetComponent<DialogueManager>().NPC1_1();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dialoguemanager.GetComponent<DialogueManager>().Event_1_Sing_Out();
        }
    }
}
