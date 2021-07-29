using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float h;
    float v;
    float speed = 7;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        h = Input.GetAxis("Horizontal") * speed;
        v = Input.GetAxis("Vertical") * speed;
        rb.velocity = new Vector3(h, rb.velocity.y, v);
    }
}
