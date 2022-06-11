using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    //Movement 
    public float moveSpeed = 5f;
    bool facingRight = true;
    public SpriteRenderer sprite;
    Rigidbody2D rb;
    Animator anim;

    Vector2 movement;

    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement() 
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if(movement.x > 0 && !facingRight)
        {
            Flip();
        }else if (movement.x < 0 && facingRight)
        {
            Flip();
        }
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    void Flip(){

        facingRight = !facingRight;
        sprite.flipX = !facingRight;
    }
}
