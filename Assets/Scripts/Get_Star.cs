using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Star : MonoBehaviour
{

    public GameObject Star_ain;

    public int start;
    public int end; 

    bool non;
    public void OnTriggerEnter(Collider other)
    {
        if (!non)
        {
             
            Star_ain.GetComponent<StarAni>().Star_Get(start, end);
            non = true;
        }

    }
}
