using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject [] ObstaclesBas; // prefab des Obstacles Bas
    public GameObject [] ObstaclesHaut; // prefab des Obstacles Haut

    [SerializeField] private float nextActionTime = 5f; // temps initial entre chaque spawn
    [SerializeField] private float period = 0.1f; // augmentation du temps entre chaque spawn
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
	{
        if (Time.timeSinceLevelLoad > nextActionTime)
        {  
            int random =Random.Range(0,2);
            if (random==0)
            {
                nextActionTime += period;
	            Instantiate(ObstaclesBas[Random.Range(0, ObstaclesBas.Length)], new Vector3(25 ,-3, -11), new Quaternion(0, 0, 0, 0)); //Vector 3 = position aléatoire sur l'axe x
                if (transform.position.x <= -40)
                {
                Destroy(gameObject); // destruction sortie de l'ecran
                }
                if (period > 1)
	            {
	            period /= 1.5f;
	            }
	            else
	            {
	            period -= 0.01f;
	            }
            }
            else
            {
                nextActionTime += period;
	            Instantiate(ObstaclesHaut[Random.Range(0, ObstaclesHaut.Length)], new Vector3(25, 4, -11), new Quaternion(0, 0, 0, 0)); //Vector 3 = position aléatoire sur l'axe x
	            if (transform.position.x <= -40)
	            {
	                Destroy(gameObject); // destruction sortie de l'ecran
	            }
	            if (period >0.5)
	            {
	                period /= 1.5f;
	            }
	           
            }
        }
	   
    }

}
