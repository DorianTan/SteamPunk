using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject MenuPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void BtnStart()
    {
        SceneManager.LoadScene("Scenes/MainScene");
        Time.timeScale = 1f;
    }

    public void BtnCredits()
    {
        creditsPanel.SetActive(true);
        MenuPanel.SetActive(false);

    }

    public void BtnMenu()
    {
        creditsPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }


    public void BtnExit()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
}
