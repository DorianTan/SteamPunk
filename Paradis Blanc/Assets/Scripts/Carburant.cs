using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carburant : MonoBehaviour
{

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = new Vector3(transform.position.x - (MapManager.Instance.Speed * Time.deltaTime), transform.position.y, transform.position.z); // deplacement du carburant

	    if (transform.position.x <= -40)
	    {
	        Destroy(gameObject);// destruction sortie de l'ecran
	    }

    }


}
