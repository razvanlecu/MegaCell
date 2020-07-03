using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Homing2 : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    public float speed = 5f;
    public float rotateSpeed = 500f;
    private float radius = 2f;
    public GameObject explosion;
    public int damage = 20;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector2 direction = (Vector2) target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        
        rb.velocity = transform.up * speed;
    }
    
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D nearbyObject in colliders)
        {
            nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                PlayerHealth player = nearbyObject.GetComponent<PlayerHealth>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }
            }
        }
        Destroy(gameObject);
    }
    
}
