using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_1 : MonoBehaviour
{
    public GameObject dialoguemanager;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dialoguemanager.GetComponent<DialogueManager>().NPC1();
        }
    }
}
