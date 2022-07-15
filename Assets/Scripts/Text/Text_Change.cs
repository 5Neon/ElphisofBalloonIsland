using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Change : MonoBehaviour
{
    public GameObject[] Change_Object;    //바꿀 오브젝트 리스트

    public int Talking_End; // 대화 끝 정하기

    public bool Roop;       // 루프 체크

    public bool Navar_stop_talking;
    [HideInInspector] public bool Roop_Talking;

    public int Roop_int;    // 루프 문단


    int Talking = 0;                // 대화 카운트
    bool Talking_End_bool = false;  // 대화 멈춤

    public void RoopTalking()
    {
        Roop = false;
        Talking_End_bool = false;
        Change_object();
        
    }

    public void OnTriggerExit(Collider other)
    {
        Change_object();
    }



    public void Change_object()      // 바꿔치기 함수
    {
        if (Talking_End_bool && !Navar_stop_talking)
        {
            Change_Object[Talking].SetActive(false);
        }

        if (Talking_End_bool && Navar_stop_talking)
        {

        }

        if (Roop)   // 루프 활성화
        {
            if (Roop_int == Talking)
            {
                Roop_Talking = true;
                Debug.Log("루프 활성화");
            }
        }

        if (!Talking_End_bool && !Roop_Talking)      //대화 넘김
        {
            Change_Object[Talking].SetActive(false);
            Change_Object[Talking + 1].SetActive(true);
            Talking++;
        }

        if (Talking == Talking_End)                   // 대화 종료
        {
            Talking_End_bool = true;
        }

    }
}
