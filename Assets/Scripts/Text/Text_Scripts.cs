using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Scripts : MonoBehaviour
{

    public GameObject textmanager; // 텍스트 매니져 

    public GameObject not_again;

    public int Dialog_Content; // 내부 대화 내용
    public int Dialog_Name; // 내부 인물 이름
    public int Dialog_FinerContent; // 마지막 페이지

    public bool not_agine_Talk;
    bool nop;

    TextManager gamemanager;

    public  void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !nop)
        {
            GameManager.isTalking = true;
            gamemanager = textmanager.GetComponent<TextManager>(); //참조를 위한 재선헌
            StartCoroutine(gamemanager.Dialogue(Dialog_Name, Dialog_Content, Dialog_FinerContent)); //코루틴 시작 함수
            if (not_agine_Talk)
            {
                nop = true;
            }
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
              
        }
    }
    IEnumerator Num()
    {
        int i = 0;
        while (true)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                i++;
                if (i == Dialog_FinerContent +2)
                {

                    not_again.SetActive(false);
                    yield break;
                }
            }
        }
    }
}
