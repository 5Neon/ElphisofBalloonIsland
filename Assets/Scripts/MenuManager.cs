using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;


    void Update()
    {
        //메뉴 
        if (Input.GetButtonDown("Cancel"))
        {
            //메뉴 false
            if (menu.activeSelf)
            {
                Time.timeScale = 1.0f;
                Debug.Log("시간 활성화");
                menu.SetActive(false);
            }
            //메뉴 true
            else
            {
                Time.timeScale = 0f;
                Debug.Log("시간 비활성화");
                menu.SetActive(true);
            }
        }
    }

    public void Restart()
    {
        //게임 시간 활성화
        Debug.Log("시간 활성화");
        Time.timeScale = 1.0f;
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
   

    public void GameExit()
    {
        // 게임 종료
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();   
        Debug.Log("게임 종료");
#endif
    }
}

