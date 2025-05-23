using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Collectible : MonoBehaviour
{
    public Sprite collectedSprite;
    SpriteRenderer sr;
    bool collected; 

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Collect()
    {
        if (collected) return;

        collected = true;
        sr.sprite = collectedSprite;

        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider != null) collider.enabled = false; // Disable Collider

        gameObject.tag = "Untagged"; // Remove Collectible tag
    }
}
