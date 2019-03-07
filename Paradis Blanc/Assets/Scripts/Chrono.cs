using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chrono : MonoBehaviour
{
    public float chrono;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LivesManagement.Instance.Health==0)
        { 
            return;
        }
        GetComponent<Text>().text = chrono.ToString("f2");

        chrono=Time.timeSinceLevelLoad;
    }
    
}
