using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarAni : MonoBehaviour
{
    public GameObject[] star_ain;
    public Image fade;

    public GameObject fade_in_go;
    public Image fade_in;

    public GameObject[] star_get;

    public GameObject textmanager;
    TextManager gamemanager;

    bool isTlaking;

    float fadeCount = 0f;
    int star_get_int = 0;

    void Update()
    {
        if (isTlaking)
        {
            GameManager.isTalking = true;
        }
    }

    public void Star_Get(int Fs, int last)
    {
        StartCoroutine(WaitTime(Fs, last));
    }

    IEnumerator WaitTime(int Fs, int last)
    {
        isTlaking = true;
        fade_in_go.SetActive(true);
        StartCoroutine(FadeCoroutine_in());
        yield return new WaitForSeconds(1f);
        star_ain[star_get_int].SetActive(true);
        yield return new WaitForSeconds(1.7f);
        StartCoroutine(FadeCoroutine());
        star_get[star_get_int].SetActive(true);
        star_ain[star_get_int].SetActive(false);
        yield return new WaitForSeconds(1.5f);
        all_star_reset();
        StartCoroutine(Start_Talk(Fs, last));
        star_get_int++;
    }

    public void all_star_reset()
    {
        for (int i = 0; i < star_get_int + 1; i++)
        {
            //Debug.Log(i);
            star_get[i].SetActive(false);
            star_get[i].SetActive(true);
        }
    }

    IEnumerator Start_Talk(int Fs, int last)
    {
        yield return null;
        isTlaking = false;
        fade_in_go.SetActive(false);
        GameManager.isTalking = true;
        Debug.Log(Fs);
        gamemanager = textmanager.GetComponent<TextManager>();                                      //참조를 위한 재선헌
        StartCoroutine(gamemanager.Dialogue(Fs, Fs, last));     //코루틴 시작 함수

    }

    IEnumerator FadeCoroutine()
    {
        fadeCount = 1f;
        while (true)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);     //0.01초마다 실행

            fade.color = new Color(255, 255, 255, fadeCount);
            if (fadeCount < 0.0f)
            {
                yield break;
            }
        }
    }

    IEnumerator FadeCoroutine_in()
    {
        fadeCount = 0f;
        while (true)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);     //0.01초마다 실행

            fade.color = new Color(0, 0, 0, fadeCount);
            if (fadeCount > 0.4f)
            {
                yield break;
            }
        }
    }
}
