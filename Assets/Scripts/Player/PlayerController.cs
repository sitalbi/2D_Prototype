using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private int movementSpeed;

    [SerializeField] private float jumpForce,
        dashDuration,
        dashForce,
        dashCoolDown;

    [SerializeField] 
    private Transform groundCheck,
        wallCheck;

    [SerializeField] 
    private LayerMask groundLayer,
        wallLayer;

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private int _facingDirection = 1;

    private bool _facingRight = true;
    private bool _isGrounded;
    private bool _canJump;
    private bool _canDash;
    private bool _isDashing;
    private bool _canMove;
    private bool isTouchingWall;
    
    private float _horizontalAxis;
    private float dashTimeLeft;
    private float dashCoolDownLeft;

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
    }

    void FixedUpdate() {
        ApplyMovement();
        CheckSurroundings();
        ApplyDash();
    }

    private void CheckCanAction() {
        // Can jump (for double jump: use an integer numberOfJumpLeft & check if it is > 0)
        if (_isGrounded) {
            if(!_isDashing) _canJump = true;
            else {
                _canJump = false;
            }
        }
        else {
            _canJump = false;
        }

        // Case dashing
        if (_isDashing) {
            _canDash = false;
            _canMove = false;
        }
        else {
            dashCoolDownLeft -= Time.deltaTime;
            _canDash = dashCoolDownLeft <= 0;
            _canMove = true;
        }
    }

    private void CheckSurroundings() {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, 0.1f, wallLayer);
    }

    private void CheckInput() {
        _horizontalAxis = Input.GetAxisRaw("Horizontal");
        
        //Jump input
        if (Input.GetKeyDown("up") && _canJump) {
            Jump();
        }
        
        //Dash input
        if (Input.GetKeyDown(KeyCode.Space) && _canDash) {
            DashInput();
        }
    }

    private void DashInput() {
        _isDashing = true;
        dashTimeLeft = dashDuration;
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

        _facingDirection = _facingRight ? 1 : -1;
    }

    private void ApplyMovement() {
        if (_canMove) {
            _rigidbody.velocity = new Vector2(movementSpeed*_horizontalAxis, _rigidbody.velocity.y);
        }
    }

    private void ApplyDash() {
        if (_isDashing) {
            if (dashTimeLeft > 0) {
                _rigidbody.velocity = new Vector2(dashForce * _facingDirection, _rigidbody.velocity.y);
                dashTimeLeft -= Time.deltaTime;
            }

            if (dashTimeLeft <= 0 ||isTouchingWall) {
                _isDashing = false;
                dashCoolDownLeft = dashCoolDown;
            }

        }
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