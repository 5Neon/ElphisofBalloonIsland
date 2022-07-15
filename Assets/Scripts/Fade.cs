using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    float fadeCount = 0f;
    public GameObject textmanager;
    TextManager gamemanager;

    public int Dialog_Content;          // 내부 대화 내용
    public int Dialog_Name;             // 내부 인물 이름
    public int Dialog_FinerContent;

    public Image fade;
    void Start()
    {
        GameManager.isTalking = true;
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine()
    {
        yield return new WaitForSeconds(1f);
        fadeCount = 1f;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);     //0.01초마다 실행

            fade.color = new Color(0, 0, 0, fadeCount);
            if (fadeCount < 0.0f)
            {
                gamemanager = textmanager.GetComponent<TextManager>();                                
                StartCoroutine(gamemanager.Dialogue(Dialog_Name, Dialog_Content, Dialog_FinerContent));
            }
        }
    }

}
