using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour
{
    PlayerHealth playerHealth;
    public float healthBonus = 100f;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (playerHealth.health < playerHealth.startHealth)
        {
            Destroy(gameObject);
            playerHealth.health = healthBonus;
        }
    }
}
