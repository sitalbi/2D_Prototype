using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BasicEnemyController : MonoBehaviour
{
    private enum State
    {
        Move,
        Attack,
        Damage,
        Dead
    }

    private State currentState;

    [SerializeField] 
    private int maxHealth, damageCost;
    [SerializeField] 
    private float groundCheckDistance, 
        wallCheckDistance,
        playerCheckDistance,
        movementSpeed,
        attackRange,
        attackRate;
    [SerializeField] 
    private Transform groundCheck,
        wallCheck,
        playerCheck,
        attackPoint;
    [SerializeField] 
    private LayerMask groundLayer, playerLayer, damageableLayer;
    [SerializeField] 
    private Vector2 knockbackSpeed;
    
    private Animator _animator;

    private Rigidbody2D rb2D;

    private int facingDirection, damageDirection;

    private float currentHealth,
        damageStartTime,
        attackStartTime,
        attackLength,
        damageInvincibilityTime;

    private Vector2 movement;
    
    private bool
        groundDetected,
        wallDetected,
        playerDetected;

    private void Start() {
        _animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        facingDirection = 1;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        switch (currentState) {
            case State.Move:
                UpdateWalkingState();
                break;
            case State.Attack:
                UpdateAttackState();
                break;
            case State.Damage:
                UpdateDamageState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;
        }   
    }
    
    // WALKING STATE

    private void EnterWalkingState() {
        _animator.SetBool("isMoving", true);
    }
    
    private void UpdateWalkingState() {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, groundLayer);
        playerDetected = Physics2D.Raycast(playerCheck.position, transform.right, playerCheckDistance, playerLayer);

        if (!groundDetected || wallDetected) {
            Flip();
        } else {
            if (rb2D.velocity.y == 0) {
                // Move
                movement.Set(movementSpeed*facingDirection, rb2D.velocity.y);
                rb2D.velocity = movement;
            }
        }

        if (playerDetected) {
            SwitchState(State.Attack);
        }
    }

    private void ExitWalkingState() {
        _animator.SetBool("isMoving", false);
    }
    
    // ATTACK STATE

    private void EnterAttackState() {
        _animator.SetTrigger("Attack");
        attackLength = _animator.GetCurrentAnimatorStateInfo(0).length + attackRate;
        attackStartTime = Time.time;
    }
    
    private void UpdateAttackState() {
        if (Time.time >= attackLength + attackStartTime) {
            if (!playerDetected) {
                SwitchState(State.Move);
            }
        }
    }

    private void ExitAttackState() {
    }
    
    // DAMAGE STATE

    private void EnterDamageState() {
        _animator.SetTrigger("Damage");
        if(damageInvincibilityTime == 0) attackLength = _animator.GetCurrentAnimatorStateInfo(0).length;
        damageStartTime = Time.time;
        movement.Set(knockbackSpeed.x * damageDirection, knockbackSpeed.y);
        rb2D.velocity = movement;
    }
    
    private void UpdateDamageState() {
        if (Time.time >= damageStartTime + damageInvincibilityTime) {
            SwitchState(State.Move);
        }
    }

    private void ExitDamageState() {
    }
    
    // DEAD STATE

    private void EnterDeadState() {
        Destroy(gameObject);
    }
    
    private void UpdateDeadState() {
        
    }

    private void ExitDeadState() {
        
    }
    
    // OTHERS
    
    private void Attack() {
        attackPoint.gameObject.SetActive(true);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, damageableLayer);

        foreach (Collider2D enemy in hitEnemies) {
            //enemy.gameObject.GetComponent<PlayerLife>().Damage(attackDetails);
        }
    }

    private void Damage(float[] attackDetails) {
        currentHealth -= attackDetails[0];

        float distance = attackDetails[1] - transform.position.x;
        damageDirection = distance > 0 ? -1 : 1;

        if (currentHealth > 0) {
            SwitchState(State.Damage);
        }
        else {
            SwitchState(State.Dead);
        }
    }
    
    private void Flip() {
        facingDirection *= -1;
        transform.Rotate(0.0f,180.0f,0.0f);
    }
    

    private void SwitchState(State state) {
        switch (currentState) {
            case State.Move:
                ExitWalkingState();
                break;
            case State.Attack:
                ExitAttackState();
                break;
            case State.Damage:
                ExitDamageState();
                break;
            case State.Dead:
                ExitDeadState();
                break;
        }
        
        switch (state) {
            case State.Move:
                EnterWalkingState();
                break;
            case State.Attack:
                EnterAttackState();
                break;
            case State.Damage:
                EnterDamageState();
                break;
            case State.Dead:
                EnterDeadState();
                break;
        }
    }

    
}
