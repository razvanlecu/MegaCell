using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage = 100;

 private void OnTriggerEnter2D(Collider2D hitInfo)
 {
     PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
     if (player != null)
     {
         player.TakeDamage(damage);
     }
 }

}
