using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject GameStart_Ui;
    public Image Fade;
    [Space(10)]

    private float fadeCount = 1.0f;         // 초기화, 알파갚 최대
    public float fademultiflyer = 0.005f;   // Fade 감소량

    void Start()
    {
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine()
    {
        while (fadeCount > 0.0f)
        {
            fadeCount -= fademultiflyer;

            yield return new WaitForSeconds(0.01f);         // 0.01초마다 실행

            Fade.color = new Color(0, 0, 0, fadeCount);     // 알파갚 하락

            if (fadeCount < 0.0f)
            {
                GameStart_Ui.gameObject.SetActive(false);

                yield break;
            }
        }
    }
}
