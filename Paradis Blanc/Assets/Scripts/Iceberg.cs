using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Iceberg : MonoBehaviour
{
    private PlayableDirector timeline;

    // Start is called before the first frame update
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End()
    {
        GameManager.Instance.End();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        timeline.Play();

    }
}
