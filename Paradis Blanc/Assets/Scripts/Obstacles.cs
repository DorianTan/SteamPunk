using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private AudioSource MetalSound;
    private AudioSource PlasticSound;

    // Start is called before the first frame update
    void Start()
    {
        MetalSound = GetComponent<AudioSource>();
        PlasticSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - (MapManager.Instance.Speed * Time.deltaTime), transform.position.y,transform.position.z); // deplacement des obstacles

        if (transform.position.x <= -40)
        {
            Destroy(gameObject);// destruction sortie de l'ecran
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!GameManager.Instance.Player.Invincibility)
        {
            LivesManagement.Instance.Health -= 1;
            if (col.gameObject.tag == "Metal")
            {
                MetalSound.Play();
            }
            else
            {
                PlasticSound.Play();
            }
        }
    }
}
