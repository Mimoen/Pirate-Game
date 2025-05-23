using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;

    // OWN GAME VERSION
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            gameObject.SendMessage("Die"); // Sends "Die" message to components
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // Takes damage when hit by bullet
    {
        if (collision.GetComponent<Bullet>() != null)
        {
            TakeDamage(10);
        }
    }
}
