using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; 
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
       
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
  
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * speed;

        rb.velocity = movement;

        LimitScreen();

    }

    void LimitScreen()
    {
        if (transform.position.x > 2.5f ){ //limite dx
            transform.position = new Vector3 (2.5f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -2.5f) //limite sx
        {
            transform.position = new Vector3(-2.5f, transform.position.y, transform.position.z);
        }

        if (transform.position.y > 1.4f) //limite superiore
        {
            transform.position = new Vector3(transform.position.x, 1.4f, transform.position.z);
        }

        if (transform.position.y < -1.07f) //limite inferiore 
        {
            transform.position = new Vector3(transform.position.x, -1.07f, transform.position.z);
        }
    }
}
