using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade_In : MonoBehaviour
{
    public GameObject textmanager;

    public GameObject Start_Content_Trigger;

    public AudioSource Audio;

    public bool[] Fade_in;

    public int Talk_int;
    public int End_Cut;
    public float[] Waiting_Time;
    public Image[] Fade;

    public int Content, Name, FinerContent;

    public bool start;


    float fadeCount = 1.0f;     //?????? ?????? ????
    int Content_V = 0;

    TextManager gamemanager;

    public void Start()
    {
        GameManager.isTalking = true;
        StartCoroutine(Fade_Trigger(-1));
    }

    IEnumerator Fade_Trigger(int UI_Conte)
    {
        while (true)
        {
            GameManager.isTalking = true;
            UI_Conte++;
            yield return new WaitForSeconds(Waiting_Time[UI_Conte]);
            if (UI_Conte != Talk_int)
            {
                StartCoroutine(FadeCoroutine(UI_Conte));
                if (UI_Conte == End_Cut)
                {
                    if (start)
                    {
                        StartCoroutine(Sound_Fade());
                        //SceneManager.LoadScene(2);
                        yield break;
                    }
                    if (!start)
                    {
                        StartCoroutine(FadeCoroutine(UI_Conte));
                        yield return new WaitForSeconds(Waiting_Time[UI_Conte]);
                        GameManager.isTalking = false;
                        Start_Content_Trigger.SetActive(false);
                        yield break;
                    }
                }
            }

            //Debug.Log(UI_Conte);
            if (UI_Conte == Talk_int)
            {
                gamemanager = textmanager.GetComponent<TextManager>(); //?????? ???? ??????
                StartCoroutine(gamemanager.Dialogue(Content, Name, FinerContent)); //?????? ???? ????
                while (true)
                {
                    yield return null;

                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                    {
                        Content_V++;
                    }
                    //Debug.Log(Content_V);
                    if (Content_V == FinerContent + 1)
                    {
                        Content_V = 0;
                        StartCoroutine(FadeCoroutine(UI_Conte));
                        StartCoroutine(Fade_Trigger(UI_Conte));
                        yield break;
                    }

                }

            }

        }

    }

    IEnumerator Sound_Fade()
    {
        while (true)
        {
            Audio.volume -= Time.deltaTime * 0.4f;
            yield return null;
            if (Audio.volume < 0.1)
            {
                SceneManager.LoadScene(2);
                yield break;
            }
        }
    }

    IEnumerator FadeCoroutine(int UI_Conte)
    {
        if (Fade_in[UI_Conte])
        {
            //Debug.Log("????");
            fadeCount = 1.0f;
            while (fadeCount > 0.0f)
            {
                fadeCount -= 0.01f;
                yield return new WaitForSeconds(0.01f);     //0.01?????? ????

                Fade[UI_Conte].color = new Color(255, 255, 255, fadeCount);
                if (fadeCount < 0.0f)
                {
                    yield break;
                }
            }
        }
        if (!Fade_in[UI_Conte])
        {
            //Debug.Log("??????");
            fadeCount = 1f;
            while (fadeCount > 0.0f)
            {
                fadeCount -= 0.01f;
                yield return new WaitForSeconds(0.01f);     //0.01?????? ????

                Fade[UI_Conte].color = new Color(0, 0, 0, fadeCount);
                if (fadeCount < 0.0f)
                {
                    yield break;
                }
            }
        }

    }
}
