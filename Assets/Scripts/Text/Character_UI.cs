using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Character_UI : MonoBehaviour
{
    public int All_Object;
    
    public GameObject[] end_Talk;

    public GameObject[] Elphis;

    public GameObject[] Plila;

    public GameObject[] Demos;

    public GameObject[] Gerffa;

    public GameObject[] Oikos;

    public GameObject[] Trophy;

    public GameObject[] Forbos;

    public GameObject[] Quiz;



    public IEnumerator Text_UI_image(int Content) // 캐릭터 UI
    {
        
        yield return null;

        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");

        string charater = data_Dialog[Content]["UI"].ToString();
        string Image = data_Dialog[Content]["Image"].ToString();

        All_UI_Stop();

        if (charater == "Elphis_nomal")  // 주인공
        {
            Elphis [0].SetActive(true);
        }
        if (charater == "Elphis_happy")
        {
            Elphis[1].SetActive(true);
        }
        if (charater == "Elphis_bed")
        {
            Elphis[2].SetActive(true);
        }
        if (charater == "Elphis_surprised")
        { 
            Elphis[3].SetActive(true);
        }
        if (charater != "Elphis_nomal" && charater != "Elphis_happy" && charater != "Elphis_bed" && charater != "Elphis_surprised")
        {
            Elphis[4].SetActive(true);
        }


        if (charater == "pilia_nomal")  // 요정
        {
            Plila[0].SetActive(true);
        }
        if (charater == "pilia_awe")
        {
            Plila[1].SetActive(true);
        }
        if (charater == "pilia_Curiosity")
        {
            Plila[2].SetActive(true);
        }
        if (charater == "pilia_Angry")
        {
            Plila[3].SetActive(true);
        }
        if (charater == "pilia_happy")
        {
            Plila[4].SetActive(true);
        }
        if (charater == "pilia_Sad")
        {
            Plila[5].SetActive(true);
        }
        if (charater == "pilia_Panic")
        {
            Plila[6].SetActive(true);
        }


        if (charater == "Demos_nomal")  // 앙마
        {
            Demos[0].SetActive(true);
        }
        if (charater == "Demos_happy")
        {
            Demos[1].SetActive(true);
        }
        if (charater == "Demos_Sad")
        {
            Demos[2].SetActive(true);
        }


        if (charater == "Gerffa_nomal") // 주민
        {
            Gerffa[0].SetActive(true);
        }
        if (charater == "Gerffa_happy1") 
        {
            Gerffa[1].SetActive(true);
        }
        if (charater == "Gerffa_happy2")
        {
            Gerffa[2].SetActive(true);
        }
        if (charater == "Gerffa_sad")
        {
            Gerffa[3].SetActive(true);
        }

        if (charater == "Oikos_nomal")
        {
            Oikos[0].SetActive(true);
        }
        if (charater == "Oikos_sad")
        {
            Oikos[1].SetActive(true);
        }
        if (charater == "Oikos_happy1")
        {
            Oikos[2].SetActive(true);
        }
        if (charater == "Oikos_happy2")
        {
            Oikos[3].SetActive(true);
        }

        if (charater == "Forbos_nomal")
        {
            Forbos[0].SetActive(true);
        }
        if (charater == "Forbos_sad")
        {
            Forbos[1].SetActive(true);
        }
        if (charater == "Forbos_happy1")
        {
            Forbos[2].SetActive(true);
        }
        if (charater == "Forbos_happy2")
        {
            Forbos[3].SetActive(true);
        }

        if (charater == "Trophy_nomal")
        {
            Trophy[0].SetActive(true);
        }
        if (charater == "Trophy_sad")
        {
            Trophy[1].SetActive(true);
        }
        if (charater == "Trophy_happy1")
        {
            Trophy[2].SetActive(true);
        }
        if (charater == "Trophy_happy2")
        {
            Trophy[3].SetActive(true);
        }

        if (Image == "Color_Quiz")
        {
            Quiz[0].SetActive(true);
        }
    }


    public void All_UI_Stop()
    {
        for (int i = 0; i < All_Object; i++)
        {
            end_Talk[i].GetComponent<Null_UI>().All_Stop();
        }
        
    }
}
