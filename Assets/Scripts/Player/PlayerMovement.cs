using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int movementSpeed;
    [SerializeField] private float jumpForce;

    private Animator animator;
    private Rigidbody2D rigidbody;
    private bool facingRight = true;
    private bool canJump;
    private float reducedSpeed = 1f;

    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(Input.GetAxis("Horizontal") * (movementSpeed * reducedSpeed)  * Time.deltaTime, 0, 0);
        
        canJump = Mathf.Abs(rigidbody.velocity.y)==0;

        //Flip the sprite according to the direction
        if(Input.GetAxis("Horizontal") < 0 && facingRight)
        {
            FlipSprite();
        } else if (Input.GetAxis("Horizontal") > 0 && !facingRight)
        {
            FlipSprite();
        }
        
        //AnimatorManagement();
    }

    void FixedUpdate() {
        if (Input.GetAxis("Horizontal")>0) {
            rigidbody.velocity = new Vector2(movementSpeed, rigidbody.velocity.y);
        } else if (Input.GetAxis("Horizontal")<0) {
            rigidbody.velocity = new Vector2(-movementSpeed, rigidbody.velocity.y);
        }
        else {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
        
        if (Input.GetKey(KeyCode.Space) && canJump) {
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
        animator.SetFloat("horizontalVelocity", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetFloat("verticalVelocity",rigidbody.velocity.y);

        switch (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name) {
            case "playerAttack":
                movementSpeed /= 2;
                break;
            default:
                movementSpeed *= 2;
                break;
        }
    }
    
}