using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScripts : MonoBehaviour
{
    public bool isPause = false;
    public GameObject PauseMenuUI;
    public GameObject[] MenuObject;
    public TimeDeltaTime TimeS;
    public Player player;
    public void exit()
    {
        Application.Quit();
    }
    public void Update()
    {
        if (!TimeS.stop)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPause)
                {

                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

    }
    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            for (int i = 0; i < MenuObject.Length; i++)
            {
                if (MenuObject[i].activeInHierarchy)
                {
                    Time.timeScale = 0f;
                    isPause = true;
                    break;
                }
                else { }
            }

            if (!isPause)
            {
                Pause();
            }
        }
        else
        {
            for (int i = 0; i < MenuObject.Length; i++)
            {
                if (MenuObject[i].activeInHierarchy)
                {
                    Time.timeScale = 1f;
                    isPause = false;
                    break;
                }
                else { }

            }
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            for (int i = 0; i < MenuObject.Length; i++)
            {
                if (MenuObject[i].activeInHierarchy)
                {
                    Time.timeScale = 0f;
                    isPause = true;
                    break;
                }
                else {  }

            }
            if (!isPause)
            {
                Pause();
            }
        }
        else
        {
            for (int i = 0; i < MenuObject.Length; i++)
            {
                if (MenuObject[i].activeInHierarchy)
                {
                    Time.timeScale = 1f;
                    break;
                }
                else { }

            }
        }
    }

    public void Pause()
    {

        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
        FindObjectOfType<AudioManager>().StopSound("Move");

    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
        if (player.isGrounded)
        {
            FindObjectOfType<AudioManager>().Play("Move");
        }

    }
}
