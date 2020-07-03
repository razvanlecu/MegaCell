using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
     public float speed;
     private bool movingUp = false;
     public Transform groundDetect;
     public Transform groundDetect2;
     private bool facing;

     private void Update()
     {
          transform.Translate(Vector2.down * speed * Time.deltaTime);
         

          RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, 2f);
          RaycastHit2D groundInfo2 = Physics2D.Raycast(groundDetect2.position, Vector2.up, 2f);
          Debug.DrawRay(transform.position, Vector3.down, Color.red);
          if (groundInfo.collider == true || groundInfo2 == true)
          {
               if (movingUp)
               {
                    transform.Translate(Vector2.down * speed * Time.deltaTime);
                    movingUp = false;
                   
               }
               if(movingUp == false)
               {
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                    movingUp = true;
               }
          }

     }
}
