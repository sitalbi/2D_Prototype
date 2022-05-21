using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int movementSpeed;
    [SerializeField] private float jumpForce;

    private Animator animator;
    private Rigidbody2D rigidbody;
    private bool facingRight = true;
    private bool canJump;
    private float horizontalAxis;
    public bool isHurt;

    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        horizontalAxis = Input.GetAxis("Horizontal");
        canJump = Mathf.Abs(rigidbody.velocity.y) == 0;

        //Flip the sprite according to the direction
        if(horizontalAxis < 0 && facingRight)
        {
            FlipSprite();
        } else if (horizontalAxis > 0 && !facingRight)
        {
            FlipSprite();
        }
        
        AnimatorManagement();
    }

    void FixedUpdate() {
        if (Input.GetKey("right")) {
            rigidbody.velocity = new Vector2(movementSpeed, rigidbody.velocity.y);
        } else if (Input.GetKey("left")) {
            rigidbody.velocity = new Vector2(-movementSpeed, rigidbody.velocity.y);
        }
        /* Knockback when hurt (not optimal implementation)
        else if(isHurt) {
            int direction = (facingRight ? -1 : 1);
            rigidbody.AddForce(new Vector2(200*direction, 20), ForceMode2D.Impulse);
            isHurt = false;
        }
        */
        else {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
        
        if (Input.GetKey("up") && canJump) {
            rigidbody.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
        }
    }


    private void FlipSprite()
    {
        // Switch the way the player is facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void AnimatorManagement() {
        animator.SetFloat("horizontalVelocity", Mathf.Abs(horizontalAxis));
        animator.SetFloat("verticalVelocity",rigidbody.velocity.y);
    }
    
}