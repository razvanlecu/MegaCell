using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    public float playerRange;
    public GameObject enemyBullet;
    public PlayerHealth player;
    public Transform firePoint;
    public float wait;
    private float counter;
    private Ray vision;
    private RaycastHit rayHit;
    

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        counter = wait;

    }

    private void Update()
    {


        counter -= Time.deltaTime;

       if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x &&
            player.transform.position.x < transform.position.x + playerRange && counter < 0)
        {
            Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
            counter = wait;
        }
        
        if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x &&
            player.transform.position.x > transform.position.x - playerRange && counter < 0)
        {
            Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
            counter = wait;
        }

    }
}
