using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject ui;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Toggle();
        }
    }

    public void Toggle() // marche pour le bouton "continue"
    {
        ui.SetActive(!ui.activeSelf); //plus simple pour basculer d'un état à l'autre

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle(); //être sûr que le temps est arrêter
        SceneManager.LoadScene("Scenes/MainScene");

    }

    public void Menu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
