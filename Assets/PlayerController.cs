using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float Speed = 5f;

    public float Horizontal;

    public float Vertical;

    public int Health;
    void Update() {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(Horizontal, Vertical, 0f) * Speed * Time.deltaTime;
        transform.Translate(movement);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            Debug.Log("Player encostou em trigger");
        }
    }












}
