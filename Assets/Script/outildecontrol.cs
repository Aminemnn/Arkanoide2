using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outildecontrol : MonoBehaviour
{
     public float speed = 150.0f;    
    

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
    }
    
}
