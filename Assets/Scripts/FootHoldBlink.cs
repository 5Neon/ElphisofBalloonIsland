using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootHoldBlink : MonoBehaviour
{
    GameObject foothold;
    bool active = true;

    void Start()
    {
        foothold = GameObject.Find("Group");

        StartCoroutine(Blink());
    }

    void Update()
    {
        if (GameManager.doJumpMap)
        {
            if (active)
            {
                foothold.SetActive(true);
            }
            else
            {
                foothold.SetActive(false);
            }
        }
    }

    public IEnumerator Blink()
    {
        active = false;
        yield return new WaitForSecondsRealtime(2f);

        active = true;
        yield return new WaitForSecondsRealtime(2f);

        StartCoroutine(Blink());
    }
}
