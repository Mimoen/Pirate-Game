using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GuardAI : EnemyDetector
{
    [SerializeField] GameObject exclamation;

    float reactionTimer;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void DetectPlayer()
    {
        base.DetectPlayer();
    }

    protected override void OnPlayerDetected()
    {
        // Debug.Log("Guard engaging the player!");
        reactionTimer -= Time.deltaTime;

        if (reactionTimer <= 0)
        {
            GameObject exclamationPrefab = Instantiate(exclamation, transform.position, transform.rotation);
            Destroy(exclamationPrefab, 2f);
            reactionTimer = 5;
        }
    }
}