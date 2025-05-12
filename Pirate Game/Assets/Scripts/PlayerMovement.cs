using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(1, 50)] float force = 7; // Ship speed
    [SerializeField, Range(1, 50)] float rotForce = 7; // Ship rotation speed
    [SerializeField, Range(1, 50)] float torqueLimit = 7;
    [SerializeField, Range(1, 50)] float speedLimitX = 7;
    [SerializeField, Range(1, 50)] float speedLimitY = 7;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Reads input from keyboard and controller 
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        rb.AddTorque(-horz * rotForce * Time.deltaTime); // Rotates the ship
        rb.AddForce(transform.up * vert * force * Time.deltaTime); // Applies force to move the ship

        // Limits ship speed and rotation speed
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -speedLimitX, speedLimitX), Mathf.Clamp(rb.velocity.y, -speedLimitY, speedLimitY));
        rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -torqueLimit, torqueLimit);
    }
}