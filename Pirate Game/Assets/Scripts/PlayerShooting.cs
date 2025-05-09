using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] float cooldown; // Time between firing
    [SerializeField] float offset;

    float fireTimer;
    public JollyRoger jrScript;

    void Update()
    {
        if (Input.GetButton("Fire1") && fireTimer <= 0 && jrScript.jollyRoger == true) // If Fire1 is pressed, cooldown is over and JR is active
        {
            GameObject bullet = ObjectPool.instance.GetPooledObject(transform.position + transform.up * offset, transform.rotation); // Retrieve a prefab from object pool och place in front of ship
            fireTimer = cooldown; // Reset timer
        }

        fireTimer -= Time.deltaTime;
    }
}