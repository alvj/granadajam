using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] float speed;

    SpriteRenderer sr;
    Rigidbody2D rb;
    float xAxis;
    float yAxis;


    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        if(xAxis < 0.01f)
        {
            sr.flipX = true;
        }
        else if (xAxis > 0.01f)
        {
            sr.flipX = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity = new Vector2(xAxis, yAxis) * speed;
        rb.velocity = velocity;
    }
}
