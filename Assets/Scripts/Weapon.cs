using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject grenadePrefab;
    public Animator animator;
    private float timer;
    public float fireRate = 0.4f;
    private float delay = 0.5f;
    
    void Update()
    {
        timer += Time.deltaTime;
        delay -= Time.deltaTime;
       
        if (Input.GetButton("Fire1"))
        {
            if (timer > fireRate)
            {
                ShootGun();
                timer = 0;
            }
          
            animator.SetBool("Shooting", true);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (delay < 0)
            {
                ThrowG();
                animator.SetBool("Grenade", true);
                delay = 0.5f;
            }
        }
            
        if(Input.GetButtonUp("Fire1"))
            animator.SetBool("Shooting", false);
        if (delay < 0.1f)
            animator.SetBool("Grenade", false);
                 
    }

    void ShootGun()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void ThrowG()
    {
        Instantiate(grenadePrefab, firePoint.position, firePoint.rotation);
    }

    
}
