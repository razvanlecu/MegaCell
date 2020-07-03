using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    private GameObject target;
    public GameObject explosion;
    public float rotationSpeed = 1f;
    public int damage = 20;
    private float radius = 5f;

    private Quaternion rotateToTarget;
    private Vector3 direction;

    private Rigidbody2D rb;
    void Start()
    {
        damage = 20;
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        direction = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotateToTarget = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateToTarget, Time.deltaTime *rotationSpeed);
        rb.velocity = new Vector2(direction.x*2, direction.y*2);
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
