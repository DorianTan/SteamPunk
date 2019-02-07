using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTest : MonoBehaviour
{
    float dirX, dirY;
    Rigidbody2D rig;
    public float moveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rig.velocity=new Vector2(dirX*moveSpeed,dirY*moveSpeed);
    }
}
