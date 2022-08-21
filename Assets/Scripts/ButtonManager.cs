using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] start_button;

    public GameObject[] how_to_controll;

    public GameObject[] exit;

    public Image controll;

    public float Fade_Speed;

    public bool Stop_agein;

    float fadeCount;
    public void Start_Button_Click()
    {
        SceneManager.LoadScene(1);
    }

    public void how_to_controll_Click()
    {
        StartCoroutine(Fade());
    }

    public void Exit_Button_Click()
    {
        // 게임 종료
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();   
        Debug.Log("게임 종료");
#endif
    }
    IEnumerator Fade() // 나오는 애니매이션
    {

        if (!Stop_agein)
        {
            fadeCount = 0f;
            while (true)
            {
                Stop_agein = true;
                fadeCount += 0.01f;
                yield return new WaitForSeconds(Fade_Speed);

                controll.color = new Color(255, 255, 255, fadeCount);

                if (fadeCount > 1.0f)
                {
                    while (true)
                    {
                        yield return null;

                        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                        {
                            while (true)
                            {
                                fadeCount -= 0.01f;
                                yield return new WaitForSeconds(Fade_Speed);

                                controll.color = new Color(255, 255, 255, fadeCount);
                                if (fadeCount < 0f)
                                {
                                    Stop_agein = false;
                                    yield break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void exit_button_Click()
    {

    }

    public void Start_Button()
    {
        start_button[0].SetActive(false);
        start_button[1].SetActive(true);
    }

    public void Start_Button_null()
    {
        start_button[1].SetActive(false);
        start_button[0].SetActive(true);
    }


    public void How_To_Controll()
    {
        how_to_controll[0].SetActive(false);
        how_to_controll[1].SetActive(true);
    }

    public void How_To_Controll_null()
    {
        how_to_controll[1].SetActive(false);
        how_to_controll[0].SetActive(true);
    }

    public void Exit_button()
    {
        exit[0].SetActive(false);
        exit[1].SetActive(true);
    }
    public void Exit_button_null()
    {
        exit[1].SetActive(false);
        exit[0].SetActive(true);
    }

}
