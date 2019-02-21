using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private float speed; // gère la vitesse du background récupérable par les enemies / environnement
    public float Speed
    {
        get => speed;
        set => speed = value;
    }


    [SerializeField] private GameObject[] mapPrefab; // list si plusieurs prefab du background
    [SerializeField] private float mapSize; // taille du backgroud

    private GameObject currentWall;
    private GameObject nextWall;


    public static MapManager Instance { get; private set; } // singleton récupérable par tout les objet

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        nextWall = mapPrefab[Random.Range(0, mapPrefab.Length)]; 
        currentWall = Instantiate(nextWall, transform);
    }
    
    void Update()
    {

        if (currentWall.transform.position.x <= transform.position.x - mapSize) // lorsque le background à avancer, spawn un nouveau mur de la liste
        {
            currentWall = Instantiate(nextWall, new Vector2(currentWall.transform.position.x + mapSize - speed*Time.deltaTime, currentWall.transform.position.y ), Quaternion.identity, transform);
            nextWall = mapPrefab[Random.Range(0, mapPrefab.Length)];
        }
    }
    
}
