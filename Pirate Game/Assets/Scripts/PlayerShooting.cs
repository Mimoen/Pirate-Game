using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] float cooldown; // Time between firing
    [SerializeField] float offset;

    float fireTimer;

    void Update()
    {
        if (Input.GetButton("Fire1") && fireTimer <= 0 ) // If Fire1 is pressed and cooldown is over
        {
            GameObject bullet = ObjectPool.instance.GetPooledObject(transform.position + transform.up * offset, transform.rotation); // Retrieve a prefab from object pool och place in front of ship
            fireTimer = cooldown; // Reset timer
        }

        fireTimer -= Time.deltaTime;
    }
}