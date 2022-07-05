using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            // 메뉴 Active false
            if (menu.activeSelf)
            {
                // Debug.Log("시간 활성화");
                Time.timeScale = 1.0f;
                menu.SetActive(false);
            }
            // 메뉴 Active true
            else
            {
                // Debug.Log("시간 비활성화");
                Time.timeScale = 0f;
                menu.SetActive(true);
            }
        }
    }

    public void Restart()
    {
        // 게임 시간 활성화
        // Debug.Log("시간 활성화");
        Time.timeScale = 1.0f;
    }

    public void Retry()
    {
        Debug.Log("다시하기 누름");
    }

    // 게임 종료
    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();   
        // Debug.Log("게임 종료");
#endif
    }
}

