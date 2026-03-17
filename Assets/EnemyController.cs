using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float Speed = 3f;

    public int Hp = 2;

    public Rigidbody2D Rb;

    public Transform Target;

    private void Awake(){
        Rb = GetComponent<Rigidbody2D>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update(){

        Rb.velocity = (Target.position - transform.position).normalized * Speed;

    }
}
