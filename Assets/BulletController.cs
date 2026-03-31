using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed = 10f;

    public Rigidbody2D Rb;

    public float DestroyTime = 2f;

    public int Damage = 1;

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyTimer());
    }
    private void Update()
    {
        Rb.velocity = transform.right * Speed;
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(DestroyTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerController>(out _))
        {
            return;
        }
        
        EnemyController enemy;
        if(collision.TryGetComponent<EnemyController>(out enemy))
        {
            enemy.TakeDamage(Damage);
            Destroy(gameObject); 
        }
       
    }






}
