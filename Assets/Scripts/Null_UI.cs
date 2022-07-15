using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Null_UI : MonoBehaviour
{
    public int Num;


    public void All_Stop()
    {
        for (int i = 0; i < Num; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
