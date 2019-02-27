﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carburant : MonoBehaviour
{

    public GameObject [] Carburants; // prefab des enemies

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
	        nextActionTime += period;
	        Instantiate(Carburants[Random.Range(0, Carburants.Length)], new Vector3(25 , Random.Range(-4, 4),-10), new Quaternion(0, 0, 0, 0)); //Vector 3 = position aléatoire sur l'axe x
           
            if (transform.position.x <= -40)
            {
                Destroy(gameObject);// destruction sortie de l'ecran
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
	   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
