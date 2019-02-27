﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Slider CarburantSlider;
    [SerializeField] private CanvasGroup UIelement;
    [SerializeField] private Image Carburant;

    [SerializeField] private GameObject postprocessGameObject;
    [SerializeField] private GameObject warning;

    [SerializeField] private GameObject endPanel;

    private AudioSource audioSource;
    

    [SerializeField] private float pourcentageBloomActivation; // pourcentage à partir dulequel le bloom s'active

    // Start is called before the first frame update
    void Start()
    {
        CarburantSlider.maxValue = GameManager.Instance.Player.AirMax;
        CarburantSlider.value = GameManager.Instance.Player.ActualAir;
        UIelement.alpha = CarburantSlider.value / 10;
        Carburant.fillAmount = CarburantSlider.value/10;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CarburantSlider.value = GameManager.Instance.Player.ActualAir;
        UIelement.alpha = CarburantSlider.value / 10;
        Carburant.fillAmount = CarburantSlider.value / 10;
        if (GameManager.Instance.Player.ActualAir <= GameManager.Instance.Player.AirMax * (pourcentageBloomActivation/100))
        {
            postprocessGameObject.SetActive(true);
            warning.SetActive(true);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
        }
        else
        {
            postprocessGameObject.SetActive(false);
            warning.SetActive(false);
            audioSource.Stop();
        }

        if (GameManager.Instance.end)
        {
            endPanel.SetActive(true);
            audioSource.Stop();
        }

        if (LivesManagement.Instance.Health <= 0)
        {
            audioSource.Stop();
        }
    }
    
    
}
