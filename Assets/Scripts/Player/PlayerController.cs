﻿using System;
using System.Collections;
using System.Collections.Generic;
using Props;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private PlayerData data;
    
   [SerializeField] 
    private Transform groundCheck,
        wallCheck;

    [SerializeField] 
    private LayerMask groundLayer,
        wallLayer;
    
    [SerializeField]
    private float distanceBetweenImages;

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private int _facingDirection = 1;
    private int jumpLeft;
    
    
    public bool actionPressed;

    private bool _facingRight = true;
    private bool _isGrounded;
    private bool _canJump;
    private bool _canDash;
    private bool _canFlip;
    private bool _isDashing;
    [NonSerialized] public bool _canMove;
    private bool isTouchingWall;
    [NonSerialized] public bool isDamage;
    private bool isHolding;
    
    private float _horizontalAxis;
    private float dashTimeLeft;
    private float dashCoolDownLeft;
    private float lastImageXpos;

    private Vector2 movementInput;

    private Interactable interactableObjectInRange;
    private PlayerInput playerInput;
    
    // Start is called before the first frame update
    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        actionPressed = false;

        playerInput = GetComponent<PlayerInput>();

        jumpLeft = data.doubleJump ? 1 : 0;
    }

    // Update is called once per frame
    void Update() {
        //CheckInput();
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
            jumpLeft = data.doubleJump ? 1 : 0;
            if (!_isDashing) {
                _canJump = true;
            }
            else {
                _canJump = false;
            }
        }
        else {
            if (jumpLeft > 0 &&_rigidbody.velocity.y <= 0) {
                _canJump = true;
            }
            else {
                _canJump = false;
            }
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

        // Case damage
        if (isDamage) {
            _canJump = false;
            _canMove = false;
            _canDash = false;
            _canFlip = false;
        }
        else
        {
            _canFlip = true;
        }
    }

    private void CheckSurroundings() {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, 0.1f, wallLayer);
    }

    private void CheckInput() {
        isHolding = Input.GetKey("up");
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

    public void OnMoveInput(InputAction.CallbackContext context) {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJumpInput(InputAction.CallbackContext context) {
        if (context.started && _canJump) {
            Jump();
        }

        isHolding = context.performed;
    }
    
    public void OnDashInput(InputAction.CallbackContext context) {
        if (context.started && _canDash) {
            DashInput();
        }
    }
    
    public void OnActionInput(InputAction.CallbackContext context) {
        if (interactableObjectInRange != null) {
            interactableObjectInRange.Interact();
        }
    }

    private void DashInput() {
        _isDashing = true;
        dashTimeLeft = data.dashDuration;

        PlayerRemnantImagePool.Instance.GetFromPool();
        lastImageXpos = transform.position.x;
    }


    private void CheckDirection() {
        if (_canFlip)
        {
            //Flip the player according to the direction
            if(movementInput.x < 0 && _facingRight)
            {
                Flip();
            } else if (movementInput.x > 0 && !_facingRight)
            {
                Flip();
            }

            _facingDirection = _facingRight ? 1 : -1;
        }
        
    }

    private void ApplyMovement() {
        if (_canMove) {
            _rigidbody.velocity = new Vector2(data.movementSpeed*movementInput.x, _rigidbody.velocity.y);
        }

        if (_rigidbody.velocity.y < 0) {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (data.fallMultiplier - 1) * Time.deltaTime;
        }
        else if(_rigidbody.velocity.y > 0 && !isHolding) {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (data.lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void ApplyDash() {
        if (_isDashing) {
            if (dashTimeLeft > 0) {
                _rigidbody.velocity = new Vector2(data.dashForce * _facingDirection, 0);
                dashTimeLeft -= Time.deltaTime;
                if (Math.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
                {
                    PlayerRemnantImagePool.Instance.GetFromPool();
                    lastImageXpos = transform.position.x;
                }
            }

            if (dashTimeLeft <= 0 ||isTouchingWall) {
                _isDashing = false;
                dashCoolDownLeft = data.dashCoolDown;
            }

        }
    }

    private void Jump() {
        jumpLeft--;
        _rigidbody.velocity = Vector2.up * data.jumpForce;
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f,180f,0f);
    }

    private void UpdateAnimations() {
        _animator.SetFloat("horizontalVelocity", Mathf.Abs(movementInput.x));
        _animator.SetFloat("verticalVelocity",_rigidbody.velocity.y);
    }

    public void SetInteractableObject(Interactable interactableObject) {
        interactableObjectInRange = interactableObject;
    }
}