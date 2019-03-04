using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public bool end;

    [SerializeField] private float initialSpeed;
    private float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private PlayerMouvement player;  // permet d'avoir accès au player de n'importe où
    public PlayerMouvement Player => player;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoadingScene;
    }


    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoadingScene;
    }

    //this function is activated every time a scene is loaded
    private void OnLevelFinishedLoadingScene(Scene scene, LoadSceneMode mode)
    {
        SetupScene();
        Debug.Log("Scene Loaded");
    }


    void Start()
    {
        SetupScene();

    }

    void SetupScene() // initialise le niveau
    {
        player = GameObject.FindObjectOfType<PlayerMouvement>();
        speed = initialSpeed;
        Time.timeScale = 1;
        end = false;
    }

    //public void End()
    //{
    //    Time.timeScale = 0;
    //    end = true;
    //}
}
