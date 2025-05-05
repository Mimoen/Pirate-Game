using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Range(1, 50)] float speed;

    private void OnEnable()
    {
        Invoke("DisableBullet", 5);
    }

    void DisableBullet()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        // Bullet moves forward
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Bullet becomes inactive after hitting something
    {
        gameObject.SetActive(false);
    }
}
