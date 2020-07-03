using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public int damage = 20;
    public float delay = 4f;
    public GameObject explosionEffect;
    private float countdown;
    private bool Boom = false;
    public float radius = 3.5f;
    void Start()
    {
        countdown = delay;
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !Boom)
        {
            Explode();
            Boom = true;
        }
}
    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D nearbyObject in colliders)
        {
            nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Enemy enemy = nearbyObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
        Destroy(gameObject);
    }
    
}
