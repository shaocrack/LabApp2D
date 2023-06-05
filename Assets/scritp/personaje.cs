using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{
   //variable para caminar (eje x)
    public float caminar = 2;
    //variable para saltar (eje y)
    public float saltar = 3;
    //variable para las fisicas que se tendran (movimiento,gravedad,salto,etc)
    Rigidbody2D rb2D;


    //variables para el salto mejorado
    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    void Start()
    {
        //busca los rigibody2d que es para las fisicas
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //MOVIMIENTOS EN X
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            //lo que debemos hacer es que el rb se mueva
            rb2D.velocity = new Vector2(caminar,rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);

        }else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-caminar, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else 
        {
            //que pasa si no presionamos nada pues nos mantenmos en x = 0 y resperamos y 
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);

        }

        //saltar
        if (Input.GetKey("space") && checkGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x,saltar);

        }
        if (checkGround.isGrounded==false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (checkGround.isGrounded==true)
        {
            animator.SetBool("Jump", false);
            
        }


        if (betterJump)
        {
            if (rb2D.velocity.y<0)
            {

                rb2D.velocity += Vector2.up*Physics2D.gravity.y*(fallMultiplier)*Time.deltaTime;
            }

            if (rb2D.velocity.y > 0 && Input.GetKey("space"))
            {


                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;

            }


        }


    }
}
