using System.Collections;
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
    

    [SerializeField] private float pourcentageBloomActivation; // pourcentage à partir dulequel le bloom s'active

    // Start is called before the first frame update
    void Start()
    {
        CarburantSlider.maxValue = GameManager.Instance.Player.AirMax;
        CarburantSlider.value = GameManager.Instance.Player.ActualAir;
        UIelement.alpha = 1-(CarburantSlider.value / 10);
        Carburant.fillAmount = CarburantSlider.value/10;
    }

    // Update is called once per frame
    void Update()
    {
        CarburantSlider.value = GameManager.Instance.Player.ActualAir;
        
        UIelement.alpha = 1-(CarburantSlider.value / 10);
        Carburant.fillAmount = CarburantSlider.value / 10;
        if (GameManager.Instance.Player.ActualAir <= GameManager.Instance.Player.AirMax * (pourcentageBloomActivation/100))
        {
            
            postprocessGameObject.SetActive(true);
            warning.SetActive(true);
            
            
        }
        else
        {
            postprocessGameObject.SetActive(false);
            warning.SetActive(false);
           
        }

        if (GameManager.Instance.end)
        {
            endPanel.SetActive(true);
            
        }

       
    }
    
    
}
