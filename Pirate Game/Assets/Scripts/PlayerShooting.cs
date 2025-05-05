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
        if (Input.GetButton("Fire1") && fireTimer >= cooldown) // Om vi skjuter och det går tillräckligt lång tid.
        {
            GameObject bullet = ObjectPool.instance.GetPooledObject(transform.position + transform.up * offset, transform.rotation); // Hämta ett skott från poolen och placera framför skeppet.
            fireTimer = 0; // Resetta timern.
        }

        fireTimer += Time.deltaTime;
    }
}