using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private int movementSpeed;
    [SerializeField] 
    private float jumpForce,
        dashForce;

    [SerializeField] 
    private Transform groundCheck;
    [SerializeField] 
    private LayerMask groundLayer;

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private bool _facingRight = true;
    private bool _isGrounded;
    private bool _canJump;
    private bool _canDash;
    private bool _isDashing;
    
    private float _horizontalAxis;
    private float _nextDashTime;

    // Start is called before the first frame update
    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        CheckInput();
        CheckDirection();
        UpdateAnimations();
        CheckCanAction();

        //canJump = Mathf.Abs(rigidbody.velocity.y) == 0;

        // Reinitialize isDashing variable
        /*if (!canDash) {
            isDashing = false;
        }*/
    }

    void FixedUpdate() {
        ApplyMovement();
        CheckSurroundings();
        /*//Dash
        if (Input.GetKey(KeyCode.Space) && !canJump && canDash) {
            canDash = false;
            isDashing = true;
            rigidbody.AddForce(new Vector2(dashForce*horizontalAxis,0), ForceMode2D.Impulse);
        }*/
    }

    private void CheckCanAction() {
        // Can jump (for double jump: use an integer numberOfJumpLeft & check if it is > 0)
        if (_isGrounded) {
            _canJump = true;
        }
        else {
            _canJump = false;
        }
    }

    private void CheckSurroundings() {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

    private void CheckInput() {
        _horizontalAxis = Input.GetAxisRaw("Horizontal");
        
        //Jump input
        if (Input.GetKey("up") && _canJump) {
            Jump();
        }
    }

    
    private void CheckDirection() {
        //Flip the player according to the direction
        if(_horizontalAxis < 0 && _facingRight)
        {
            Flip();
        } else if (_horizontalAxis > 0 && !_facingRight)
        {
            Flip();
        }
    }

    private void ApplyMovement() {
        _rigidbody.velocity = new Vector2(movementSpeed*_horizontalAxis, _rigidbody.velocity.y);
    }

    private void Jump() {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f,180f,0f);
    }

    private void UpdateAnimations() {
        _animator.SetFloat("horizontalVelocity", Mathf.Abs(_horizontalAxis));
        _animator.SetFloat("verticalVelocity",_rigidbody.velocity.y);
    }
    
}