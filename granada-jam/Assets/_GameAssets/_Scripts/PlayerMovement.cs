using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] float speed;

    Rigidbody2D rb;
    float xAxis;
    float yAxis;


    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity = new Vector2(xAxis, yAxis) * speed;
        rb.velocity = velocity;
    }
}
