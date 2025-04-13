using System;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (input.magnitude > 0.1f)
        {
            rb.AddForce(input * speed);
        }
    }
}
