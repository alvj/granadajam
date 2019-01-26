using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float speed;
    GameObject player;
    Rigidbody2D rb;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector3 direction = player.transform.position - transform.position;

        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }
}
