using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static bool isJumped = false;
    public static bool isTalking = false;

    [HideInInspector] public bool Delay_Text;

    public Text text;           // 대화창 내용
    public Text CharacterName;  // 인물 이름

    public GameObject Text_Ui;            // 대화창 UI
    public GameObject text_Change;        // 개채 참조

    public GameObject character_UI;

    Character_UI gamemanager;

    //bool skip_text = false;

    int String_long;
    void Update()
    {

    }
    public IEnumerator Stop_Dialogue() //다이얼로그 멈춤
    {
        yield return null;
        Text_Ui.SetActive(false);
        CharacterName.text = "";
        text.text = "";
        gamemanager.All_UI_Stop();
        StopAllCoroutines();
        yield break;
    }

    public IEnumerator Dialogue_Inout(int Content, int Name, bool isnottalk) // 다이얼로그 인_아웃 대화 스크립트
    {
        if (!Delay_Text)
        {
            gamemanager.All_UI_Stop();
            List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
            Text_Ui.SetActive(true);

            CharacterName.text = data_Dialog[Content]["Name"].ToString();
            StartCoroutine(Typing(text, data_Dialog[Name]["Content"].ToString()));

            gamemanager = character_UI.GetComponent<Character_UI>();

            if (!isnottalk)
            {
                gamemanager.All_UI_Stop();
                StartCoroutine(gamemanager.Text_UI_image(Content));
            }
            yield break;
        }

    }
    public IEnumerator Typing(Text typingText, string message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                yield break;
            }
            yield return null;
            typingText.text = message.Substring(0, i + 1);
        }

        //String_long = message.Length;

        //int i = 0;

        //while (true)
        //{


        //    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        //    {
        //        yield break;
        //    }
        //    if (i == String_long - 1)
        //    {
        //        yield break;
        //    }
        //    i++;
        //    yield return new WaitForSeconds(0.02f);
        //    typingText.text = message.Substring(0, i + 1);
        //}

    }
    public IEnumerator Dialogue(int Content, int Name, int FinerContent) // 다이얼로그 대화 스크립트
    {


        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
        Text_Ui.SetActive(true);

        CharacterName.text = data_Dialog[Name]["Name"].ToString();
        StartCoroutine(Typing(text, data_Dialog[Content]["Content"].ToString()));

        gamemanager = character_UI.GetComponent<Character_UI>();
        StartCoroutine(gamemanager.Text_UI_image(Content));
        Content++;
        Name++;

        //skip_text = true;

        while (true)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) /*&& !skip_text*/)
            {
                StopCoroutine(Typing(text, data_Dialog[Content]["Content"].ToString()));
                CharacterName.text = data_Dialog[Name]["Name"].ToString();
                yield return null;
                StartCoroutine(Typing(text, data_Dialog[Content]["Content"].ToString()));

                gamemanager = character_UI.GetComponent<Character_UI>();
                StartCoroutine(gamemanager.Text_UI_image(Content));

                Content++;
                Name++;

                if (Content == FinerContent + 2 || Input.GetKeyDown(KeyCode.Space) && Input.GetMouseButtonDown(0))
                {
                    gamemanager.All_UI_Stop();
                    GameManager.isTalking = false;
                    Text_Ui.SetActive(false);
                    yield break;
                }
            }
            //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && skip_text)
            //{
            //    Content++;
            //    Name++;

            //    StopCoroutine(Typing(text, data_Dialog[Content]["Content"].ToString()));
            //    skip_text = false;
            //}
        }
    }
}

