using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] float cooldown; // Time between firing
    [SerializeField] float offset;

    [SerializeField] Transform[] leftCannons;
    [SerializeField] Transform[] rightCannons;

    float leftFireTimer;
    float rightFireTimer;

    public JollyRoger jrScript;

    void Update()
    {
        if (Input.GetButton("Fire1") && leftFireTimer <= 0 && jrScript.jollyRoger == true) // If Fire1 is pressed, cooldown is over and JR is active
        {
            for (int i = 0; i < leftCannons.Length; i++)
            {
                GameObject bullet = ObjectPool.instance.GetPooledObject(leftCannons[i].position, leftCannons[i].rotation); // Retrieve a prefab from object pool och place on left cannons
            }
           
            leftFireTimer = cooldown; // Reset timer
        }
        if (Input.GetButton("Fire2") && rightFireTimer <= 0 && jrScript.jollyRoger == true) // If Fire1 is pressed, cooldown is over and JR is active
        {
            for (int i = 0; i < rightCannons.Length; i++)
            {
                GameObject bullet = ObjectPool.instance.GetPooledObject(rightCannons[i].position, rightCannons[i].rotation); // Retrieve a prefab from object pool och place on right cannons
            }

            rightFireTimer = cooldown; // Reset timer
        }

        rightFireTimer -= Time.deltaTime;
        leftFireTimer -= Time.deltaTime;
    }
}