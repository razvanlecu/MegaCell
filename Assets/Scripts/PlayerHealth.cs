using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float startHealth = 100;
    public GameObject deathEffect;
    public float health;
    [SerializeField] private string gameOver;
    

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

    void Update()
    {
        healthBar.fillAmount = health / startHealth;
        
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Game Over");
        Destroy(gameObject);
        
    }
 
}
