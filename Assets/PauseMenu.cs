using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{


    public GameObject firstButtonSelected, optionFirstButton, optionsClosedButton;
    public GameObject Pausemenu;
    public GameObject Optionmenu;

    private void Start()
    {
        Pausemenu.SetActive(false);
        Optionmenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Optionmenu.activeSelf == false)
            {
                Pausemenu.SetActive(!Pausemenu.activeSelf);
            }
            else if (Optionmenu.activeSelf == true && Pausemenu.activeSelf == false)
            {
                Optionmenu.SetActive(false);
                Pausemenu.SetActive(true);
            }
        }
        else if (Pausemenu.activeSelf == true || Optionmenu.activeSelf == true)
        {
            Time.timeScale = 0.0f;
        }
        else if (Pausemenu.activeSelf == false && Pausemenu.activeSelf == false)
        {
            Time.timeScale = 1.0f;
        }

    }
    public void PlayGame()
    {
        Pausemenu.SetActive(false);
        Optionmenu.SetActive(false);
        Time.timeScale = 1.0f;

    }

    public void Option()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionFirstButton);
    }

    public void OptionQuit()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;

    }
}

