using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float timeToDisappear;
    float timeLighted;
    GameObject player;
    Torch torch;
    Rigidbody2D rb;
    float inverter = 1;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        torch = player.GetComponentInChildren<Torch>();
    }

    private void Update()
    {
        Vector3 directionToEnemy = this.transform.position - torch.transform.position;
        Vector3 forward = torch.transform.forward;

        float angle = Vector3.Angle(forward, directionToEnemy);

        if ((angle + 30) < torch.GetLightAngle())
        {
            inverter = -1;
            timeLighted += Time.deltaTime;

            if(timeLighted > timeToDisappear)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            inverter = 1.5f;
            timeLighted = 0;
        }
    }

    private void FixedUpdate()
    {
        Vector3 direction = player.transform.position - transform.position;

        rb.MovePosition(transform.position + direction * speed * inverter * Time.deltaTime);
    }
}
