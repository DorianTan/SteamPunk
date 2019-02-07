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
