using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float speed;   
    Rigidbody2D rb;
    Vector2 input;
    Animator animator;

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        
        Move();


    }

    void Move()
    {
        input = input.normalized;

        
        animator.SetFloat("moveX", input.x);
        animator.SetFloat("moveY", input.y);


        rb.velocity = input.normalized * speed;

        if(rb.velocity != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
        }
        else 
        {
            animator.SetBool("isWalking", false);
        }
    }
}
