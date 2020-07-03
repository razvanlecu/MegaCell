using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed;
    private Transform target;
    private bool facing;
    public GameObject enemyBullet;
    public Transform firePoint;
    public float wait = 5f;
    private float counter;
    public GameObject canvasBoard;
    

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>().GetComponent<Transform>();
        counter = wait;
    }

    void Update()
    {
        counter -= Time.deltaTime;
        if (target != null)
        {
            if (target.transform.position.x < gameObject.transform.position.x && facing)
                Flip();
            if (target.transform.position.x > gameObject.transform.position.x && !facing)
                Flip();
        }


        if (Vector2.Distance(transform.position, target.position) > 7 && Vector2.Distance(transform.position, target.position) < 15)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
        }

        if (Vector2.Distance(transform.position, target.position) < 10 && counter < 0)
        {
            Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
            counter = wait;
        }
    }
    
    void Flip()
    {
        facing = !facing;
        transform.Rotate(0f,180f,0f);
        canvasBoard.transform.Rotate(0f, 180f, 0f);
    } 
}
