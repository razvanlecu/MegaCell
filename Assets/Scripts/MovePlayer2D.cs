using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isGrounded;
    public Animator animator;
    public Rigidbody2D rb;
    private float jumpDelay;
    private bool facing;
    public GameObject canvasBoard;

    public int jumpForce = 3;
    void Start()
    {
        facing = true;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Jump();
      Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f,0f);
      transform.position += movement * Time.deltaTime * moveSpeed;
      Flip(Input.GetAxis("Horizontal"));
      animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded && Time.time > jumpDelay)
        {
            rb.velocity = rb.velocity + new Vector2(0f, 6f);
            jumpDelay = Time.time + 0.5f;
            animator.SetBool("IsJumping", true);
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }


     private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
            
        }
    }

     private void Flip(float horizontal)
     {
         if (horizontal > 0 && !facing || horizontal < 0 && facing)
         {
             facing = !facing;
             transform.Rotate(0f,180f,0f);
             canvasBoard.transform.Rotate(0f, 180f, 0f);
         }
     } 
}
