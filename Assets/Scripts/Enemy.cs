using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startHealth = 100;
    public GameObject deathEffect;
    public float health;
    public int scoreValue = 10;

    [Header("Stuff")]
    public Image healthBar;

    private void Start()
    {
        health = startHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Score.score += scoreValue;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
