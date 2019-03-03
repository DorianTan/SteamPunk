using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManagement : MonoBehaviour
{
    public GameObject lives1, lives2, lives3;
    [SerializeField] private GameObject UIMort;

    // C'est un singleton, ça permet d'avoir accès à toutes les variables public sans mettre de variables en static
    public static LivesManagement Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private int health;
    public int Health
    {
        get { return health; }
        set
        {
            StartCoroutine(GameManager.Instance.Player.InvincibilityCouroutine());
            health = value;
           // DisplayUpdate();
            FixedUpdate();
        }
    }

    void Start()
    {
        health = 3;
        lives1.gameObject.SetActive(true);
        lives2.gameObject.SetActive(true);
        lives3.gameObject.SetActive(true);
        UIMort.gameObject.SetActive(false);
    }


    void FixedUpdate()
    {
        switch (health)
        {
            case 3:
                lives1.gameObject.SetActive(false);
                lives2.gameObject.SetActive(true);
                lives3.gameObject.SetActive(true);
                break;
            case 2:
                
                lives1.gameObject.SetActive(false);
                Debug.Log("vie");
                break;
            case 1:
                lives1.gameObject.SetActive(false);
                lives2.gameObject.SetActive(false);
                break;
            case 0:
                lives1.gameObject.SetActive(false);
                lives2.gameObject.SetActive(false);
                lives3.gameObject.SetActive(false);
                UIMort.gameObject.SetActive(true);
                Time.timeScale = 0f;
                break;
        }
    }

    //void DisplayUpdate()
    //{

    //    switch (health)
    //    {
    //        case 3:
    //            Debug.Log("toute vie");
    //            lives1.gameObject.SetActive(true);
    //            lives2.gameObject.SetActive(true);
    //            lives3.gameObject.SetActive(true);
    //            break;
    //        case 2:
    //            Debug.Log("2 vies");
    //            //lives1.gameObject.SetActive(false);
    //            lives1.GetComponent<Animator>().SetTrigger("Break");
    //            Debug.Log("casser");
    //            break;
    //        case 1:
    //            lives1.gameObject.SetActive(false);
    //            lives2.GetComponent<Animator>().SetTrigger("Break");
    //           // lives2.gameObject.SetActive(false);
    //            break;
    //        case 0:
    //            lives1.gameObject.SetActive(false);
    //            lives2.gameObject.SetActive(false);
    //            lives3.GetComponent<Animator>().SetTrigger("Break");
    //            //lives3.gameObject.SetActive(false);
    //            UIMort.gameObject.SetActive(true);
    //            Time.timeScale = 0f;
    //            break;
    //    }
    //}
}
