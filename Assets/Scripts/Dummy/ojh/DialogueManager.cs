using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject Text_Ui; //대화창
    public Text text; //채팅
    public Text CharacterName; //캐릭터 이름
    public GameObject event_Chapters; // 판정 제거용
    public GameObject Butten; // 비활성화 오브젝트
    public GameObject Star; //스타 ui

    int wrong_butten = 0; //잘못된 버튼 카운터
    int Dialog_Content = 0;
    int Dialog_Name = 0;

    public TextAsset txt;
    public int lineSize;
    public int rowSize;

    public GameObject Npc1;
    public GameObject Npc1_1;
    public GameObject moveNPC;

    public void Event_1_1()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");

        Dialog_Content = 29;
        Dialog_Name = 29;

        Text_Ui.SetActive(true);
        text.text = data_Dialog[Dialog_Content]["Content"].ToString();
        CharacterName.text = data_Dialog[Dialog_Name]["Name"].ToString();

        Dialog_Content++;
        Dialog_Name++;

        GameManager.isTalking = true;

        StartCoroutine(EventText());
        //StartCoroutine(Typing(Text typingText, string message, float speed));
    }

    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
    }
    IEnumerator EventText()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
        //Debug.Log("코루틴 시작 부분");

        while (true)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Dialog_Content++;
                Dialog_Name++;

                text.text = data_Dialog[Dialog_Content]["Content"].ToString();
                CharacterName.text = data_Dialog[Dialog_Name]["Name"].ToString();

                if (Dialog_Content == 38)
                {
                    Dialog_Content = 0;
                    Dialog_Name = 0;

                    Text_Ui.SetActive(false);
                    event_Chapters.SetActive(false);

                    GameManager.isTalking = false;
                    yield break;
                }
            }
        }
    }

    public void Event_1_Sing()
    {
        Text_Ui.SetActive(true);
        text.text = "↓ 지상세계 \n 마을 ↑";
        CharacterName.text = "표지판";
    }

    public void Event_1_Sing_Out()
    {
        Text_Ui.SetActive(false);
    }

    public void NPC1_1()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
        Text_Ui.SetActive(true);

        text.text = data_Dialog[59]["Content"].ToString();
        CharacterName.text = data_Dialog[59]["Name"].ToString();
    }

    public void NPC1()
    {
        GameManager.isTalking = true;

        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");

        Dialog_Content = 39;
        Dialog_Name = 39;

        Text_Ui.SetActive(true);
        text.text = data_Dialog[Dialog_Content]["Content"].ToString();
        CharacterName.text = data_Dialog[Dialog_Name]["Name"].ToString();

        Dialog_Content++;
        Dialog_Name++;

        StartCoroutine(npc1());
    }

    IEnumerator npc1()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");

        while (true)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Dialog_Content++;
                Dialog_Name++;

                text.text = data_Dialog[Dialog_Content]["Content"].ToString();
                CharacterName.text = data_Dialog[Dialog_Name]["Name"].ToString();

                if (Dialog_Content == 58)
                {
                    Dialog_Content = 0;
                    Dialog_Name = 0;

                    GameManager.isTalking = false;
                    Text_Ui.SetActive(false);
                    Npc1.SetActive(false);
                    Npc1_1.SetActive(true);

                    yield break;
                }
            }
        }
    }

    public void Wrong_Butten()
    {
        wrong_butten++;
        if (wrong_butten == 1)
        {
            List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");

            GameManager.isTalking = true;

            Dialog_Content = 61;
            Dialog_Name = 61;

            text.text = data_Dialog[Dialog_Content]["Content"].ToString();
            CharacterName.text = data_Dialog[Dialog_Name]["Name"].ToString();

            Text_Ui.SetActive(true);

            StartCoroutine(worng_Butten());
        }
    }

    IEnumerator worng_Butten()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");

        while (true)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Dialog_Content++;
                Dialog_Name++;

                text.text = data_Dialog[Dialog_Content]["Content"].ToString();
                CharacterName.text = data_Dialog[Dialog_Name]["Name"].ToString();

                if (Dialog_Name == 63)
                {
                    GameManager.isTalking = false;
                    Text_Ui.SetActive(false);

                    wrong_butten = 0;

                    yield break;
                }
            }
        }
    }

    public void Right_Butten()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");

        GameManager.isTalking = true;

        Star.SetActive(true);

        Dialog_Content = 64;
        Dialog_Name = 64;

        text.text = data_Dialog[Dialog_Content]["Content"].ToString();
        CharacterName.text = data_Dialog[Dialog_Name]["Name"].ToString();

        Text_Ui.SetActive(true);

        StartCoroutine(right_Butten());
    }

    IEnumerator right_Butten()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");

        while (true)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Dialog_Content++;
                Dialog_Name++;

                text.text = data_Dialog[Dialog_Content]["Content"].ToString();
                CharacterName.text = data_Dialog[Dialog_Name]["Name"].ToString();

                if (Dialog_Name == 76)
                {
                    GameManager.isTalking = false;

                    Text_Ui.SetActive(false);
                    Butten.GetComponent<ButtenTrigger>().enabled = false;

                    moveNPC.GetComponent<NPC_Move>().npc_move();

                    yield break;
                }

            }
        }
    }

    void Update()
    {

    }
}
