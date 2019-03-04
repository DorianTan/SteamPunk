using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x-(MapManager.Instance.Speed*Time.deltaTime), transform.position.y, transform.position.z); // deplacement du background

        if (transform.position.x <= -60)
        {
            Destroy(gameObject);// destruction sortie de l'ecran
        }
    }
}
