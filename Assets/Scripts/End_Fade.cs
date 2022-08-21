using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_Fade : MonoBehaviour
{

    public GameObject open_eyes_object;

    float fadeCount;

    public Image open_eyes_Fade;

    public Image Black_look;

    //public Image White;

    public Image[] Fade_image_1;
    public Image[] Fade_image_2;
    public Image[] Fade_image_3;
    public Image[] Fade_image_4;
    public Image[] Fade_image_5;

    public int[] Fade_image_int;

    public float Time_set_next;


    int page = 0;



    void Start()
    {
        End_Trigger();
    }

    public void End_Trigger()
    {
        GameManager.isTalking = true;

        StartCoroutine(Ending_start());
    }

    IEnumerator Ending_start()  //?????? 5?? ??????!!
    {
        fadeCount = 0f;
        open_eyes_object.SetActive(true);
        while (true)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);

            open_eyes_Fade.color = new Color(255, 255, 255, fadeCount);

            if (fadeCount > 0.3f)
            {
                while (true)
                {
                    fadeCount -= 0.01f;
                    yield return new WaitForSeconds(0.01f);

                    open_eyes_Fade.color = new Color(255, 255, 255, fadeCount);

                    if (fadeCount < 0.1f)
                    {
                        while (true)
                        {
                            fadeCount += 0.01f;
                            yield return new WaitForSeconds(0.01f);

                            open_eyes_Fade.color = new Color(255, 255, 255, fadeCount);
                            if (fadeCount > 1.0f)
                            {
                                yield return new WaitForSeconds(3f);
                                while (true)
                                {
                                    fadeCount -= 0.01f;
                                    yield return new WaitForSeconds(0.01f);

                                    open_eyes_Fade.color = new Color(255, 255, 255, fadeCount);
                                    if (fadeCount < 0f)
                                    {
                                        yield return new WaitForSeconds(3f);
                                        StartCoroutine(bleak_Look());
                                        yield break;
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator bleak_Look()
    {
        fadeCount = 0;
        while (true)
        {
            fadeCount += 0.007f;
            yield return new WaitForSeconds(0.01f);

            Black_look.color = new Color(255, 255, 255, fadeCount);
            if (fadeCount > 0.65f)
            {
                while (true)
                {
                    fadeCount -= 0.007f;
                    yield return new WaitForSeconds(0.01f);

                    Black_look.color = new Color(255, 255, 255, fadeCount);
                    if (fadeCount < 0.25f)
                    {
                        while (true)
                        {
                            fadeCount += 0.005f;
                            yield return new WaitForSeconds(0.01f);

                            Black_look.color = new Color(255, 255, 255, fadeCount);
                            if (fadeCount > 0.7f)

                            {
                                yield return new WaitForSeconds(1f);
                                StartCoroutine(fade_image_1());
                                yield break;
                            }
                        }

                    }
                }
            }
        }
    }
    IEnumerator fade_image_1()
    {
        int i = 0;
        fadeCount = 0;
        while (true)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Fade_image_1[i].color = new Color(255, 255, 255, fadeCount);
            if (fadeCount > 1f)
            {
                fadeCount = 0;
                ++i;
                yield return new WaitForSeconds(3f);
            }
            if (Fade_image_int[page] == i - 1)
            {
                StartCoroutine(fade_image_2());
                yield break;
            }
        }
    }

    IEnumerator fade_image_2()
    {
        int i = 0;
        fadeCount = 0;
        while (true)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Fade_image_2[i].color = new Color(255, 255, 255, fadeCount);
            if (fadeCount > 1f)
            {
                fadeCount = 0;
                ++i;
                yield return new WaitForSeconds(3f);
            }
            if (Fade_image_int[page] == i - 1)
            {
                StartCoroutine(fade_image_3());
                yield break;
            }
        }
    }

    IEnumerator fade_image_3()
    {
        int i = 0;
        fadeCount = 0;
        while (true)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Fade_image_3[i].color = new Color(255, 255, 255, fadeCount);
            if (fadeCount > 1f)
            {
                fadeCount = 0;
                ++i;
                yield return new WaitForSeconds(3f);
            }
            if (Fade_image_int[page] == i - 1)
            {
                StartCoroutine(fade_image_4());
                yield break;
            }
        }
    }
    IEnumerator fade_image_4()
    {
        int i = 0;
        fadeCount = 0;
        while (true)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Fade_image_4[i].color = new Color(255, 255, 255, fadeCount);
            if (fadeCount > 1f)
            {
                fadeCount = 0;
                ++i;
                yield return new WaitForSeconds(3f);
            }
            if (Fade_image_int[page] == i - 1)
            {
                StartCoroutine(fade_image_5());
                yield break;
            }
        }
    }

    IEnumerator fade_image_5()
    {
        int i = 0;
        fadeCount = 0;
        while (true)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Fade_image_5[i].color = new Color(255, 255, 255, fadeCount);
            if (fadeCount > 1f)
            {
                fadeCount = 0;
                ++i;
                yield return new WaitForSeconds(3f);
            }
            if (Fade_image_int[page] == i - 1)
            {
                //StartCoroutine(fade_image_3());
                yield break;
            }
        }
    }
    //IEnumerator fade_in_Wt(Image fade_image)
    //{
    //    fadeCount = 0f;
    //    while (fadeCount < 1.0f)
    //    {
    //        fadeCount += 0.01f;
    //        yield return new WaitForSeconds(0.01f);     //0.01?????? ????

    //        fade_image.color = new Color(255, 255, 255, fadeCount);

    //        if (fadeCount < 1.0f)
    //        {
    //            yield break;
    //        }
    //    }
    //}

    //IEnumerator White_open(bool i)
    //{
    //    if (i)
    //    {
    //        fadeCount = 1f;
    //        while (fadeCount > 0.0f)
    //        {
    //            fadeCount -= 0.01f;
    //            yield return new WaitForSeconds(0.01f);     //0.01?????? ????

    //            White.color = new Color(255, 255, 255, fadeCount);
    //            if (fadeCount < 0.0f)
    //            {
    //                yield break;
    //            }
    //        }

    //    }
    //    if (!i)
    //    {
    //        fadeCount = 0f;
    //        while (fadeCount < 1f)
    //        {
    //            fadeCount += 0.01f;
    //            yield return new WaitForSeconds(0.01f);

    //            White.color = new Color(255, 255, 255, fadeCount);
    //            if (fadeCount < 1f)
    //            {
    //                yield break;
    //            }
    //        }
    //    }

    //}

}
