using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public enum PlayerState
    {
        Interaction,
        Free,
    }
    [SerializeField] float speed,speedBase = 8,speedMax = 12;   
    Rigidbody2D rb;
    Vector2 input;
    Animator animator;


    bool isDashing = false;
    [SerializeField] bool canDash = true;
    float dashPower = 20f;
    float dashCD = 2f;
    float dashDuration = 0.2f;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed= speedBase;

    }

    private void LateUpdate()
    {
        if (isDashing)
        {
            return;
        }


        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        Move();
    }
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Estou colidindo");
    }



    void Move()
    {
        input = input.normalized;

        rb.velocity = input.normalized * speed;


       

        if (rb.velocity != Vector2.zero)
        {

            animator.SetBool("isWalking", true);
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);

        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        //Dash
        if (Input.GetKeyDown(KeyCode.X) && canDash)
        {
            StartCoroutine(Dash());
        }
 
        
    }

    IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;

        rb.velocity = new Vector2(input.x * dashPower, input.y * dashPower) ;

        yield return new WaitForSeconds(dashDuration);
       
        
        isDashing= false;

        yield return new WaitForSeconds(dashCD);

        canDash = true;
       


    }

    public void takeDamage(int damage)
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }
}
