using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    [SerializeField] int angleToAdd = 50;
    [SerializeField] int intensityToAdd = 10;
    [SerializeField] GameObject canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            canvas.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetButtonDown("Use"))
        {
            Torch torch = collision.gameObject.GetComponentInChildren<Torch>();

            torch.AddFuel(angleToAdd, intensityToAdd);

            canvas.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvas.SetActive(false);
        }
    }
}
