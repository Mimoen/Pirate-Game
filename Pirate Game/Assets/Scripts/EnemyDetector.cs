using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] float detectionDistance;
    [SerializeField] float detectionTime;

    float seenTimer;
    bool playerDetected;
    GameObject player;
    JollyRoger jollyRoger;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        jollyRoger = player.GetComponent<JollyRoger>();
    }

    protected virtual void Update()
    {
        DetectPlayer();

        if (playerDetected)
        {
            OnPlayerDetected();
        }
    }

    protected virtual void DetectPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position); // Distance between player and enemy

        if (distance <= detectionDistance && seenTimer < 5 && jollyRoger.jollyRoger == false) // Limited seen timer goes up when player is within distance

        {
            seenTimer += Time.deltaTime;
        }

        else if (distance <= detectionDistance && seenTimer < 5 && jollyRoger.jollyRoger == true) // Goes up at 2x speed when Jolly Roger is active
        {
            seenTimer += Time.deltaTime * 2;
        }

        else if (distance > detectionDistance && seenTimer > 0) // Goes down when not within distance
        {
            seenTimer -= Time.deltaTime;
        }

        playerDetected = seenTimer >= detectionTime;
    }

    protected virtual void OnPlayerDetected()
    {
        Debug.Log("Player Detected");
    }
}
