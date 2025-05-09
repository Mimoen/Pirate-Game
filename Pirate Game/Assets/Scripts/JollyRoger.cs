using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class JollyRoger : MonoBehaviour
{
    [SerializeField] float cooldown;
    SpriteRenderer sr;
    float heldDownTime;
    float jrTimer;
    public bool jollyRoger;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        jollyRoger = false;
    }

    void FixedUpdate()
    {

        // When space is held for 2 seconds and the cooldown is over, the Jolly Roger is raised
        if (Input.GetButton("Fire3") && jrTimer <= 0)
        {
            heldDownTime += Time.deltaTime;
            if (heldDownTime >= 2)
            {
                RaiseJollyRoger();
                heldDownTime = 0;
                jrTimer = cooldown;
                Debug.Log("Jolly Roger " + jollyRoger);
            }
        }
        else
        {
            heldDownTime = 0;
            if (jrTimer > 0)
            {
                jrTimer -= Time.deltaTime;
            }
        }
    }

    void RaiseJollyRoger()
    {
        // Changes Sprite when Jolly Roger is raised/unraised
        if (jollyRoger == false)
        {
            sr.color = Color.black;
            jollyRoger = true;
        }
        else
        {
            sr.color = Color.white;
            jollyRoger = false;
        }
    }
}
