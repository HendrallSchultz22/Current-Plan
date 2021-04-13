using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private float LifeTime = 2f;
    Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
        lifeTime();
    }
    void FixedUpdate()
    {
        rb.AddForce(transform.up * speed);
    }

    private void OnCollisionEnter2D(Collision2D i)
    {
        if (i.gameObject.GetComponent<PlayerMovement>())
        {
            Destroy(i.gameObject);
            Destroy(gameObject);
        }
    }
    void lifeTime()
    {
        Destroy(gameObject, LifeTime);
    }
}
