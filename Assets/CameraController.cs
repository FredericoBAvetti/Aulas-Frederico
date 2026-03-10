using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    public Transform Target;

    public float SmoothSpeed = 0.125f;

    private void Awake() {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        Vector3 newPos = new Vector3(Target.position.x, Target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, SmoothSpeed);
    }
}
