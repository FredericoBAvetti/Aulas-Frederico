using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float Speed = 5f;

    public float Horizontal;

    public float Vertical;

    public int Health;

    public GameObject BulletPrefab;

    public Vector2 Direction;

    void Update() {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(Horizontal, Vertical, 0f) * Speed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.RightArrow)){
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, -180);
            Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, -270);
            Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            Shoot();
        }



    }

    private void Shoot()
    {
        if (BulletPrefab != null)
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
        }
        else
        {
            Debug.Break();
        }
    }

            void OnTriggerEnter2D(Collider2D collision)
            {
                if (collision.CompareTag("Trigger"))
                {
                    Debug.Log("Player encostou em trigger");
                }
            }












}
