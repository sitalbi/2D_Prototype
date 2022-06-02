using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;
    public FinalStateMachine stateMachine;
    public EntityData entityData;
    public Rigidbody2D rigidbody { get; private set; }
    public Animator animator { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    public int facingDirection { get; private set; }

    public AnimationToStateMachine atsm { get; private set; }

    [SerializeField] private Transform wallCheck, ledgeCheck, playerCheck;
    
    private Vector2 velocityVector;

    public float health { get; set; }

    public virtual void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        atsm = GetComponent<AnimationToStateMachine>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        facingDirection = 1;
        health = entityData.health;

        stateMachine = new FinalStateMachine();
    }

    public virtual void Update() {
        stateMachine.currentState.LogicUpdate();
    }
    
    public virtual void FixedUpdate() {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity) {
        velocityVector.Set(facingDirection * velocity, rigidbody.velocity.y);
        rigidbody.velocity = velocityVector;
    }

    public virtual void SetVelocity(Vector2 velocity) {
        velocityVector.Set(velocity.x,velocity.y);
        rigidbody.velocity = velocityVector;
    }
    
    public virtual bool CheckWall() {
        return Physics2D.Raycast(wallCheck.position, transform.right, entityData.wallCheckDistance,
            entityData.groundLayer);
    }
    
    public virtual bool CheckLedge() {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance,
            entityData.groundLayer);
    }

    public virtual bool CheckInAgroRange() {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.detectDistance, entityData.playerLayer) 
               || Physics2D.Raycast(playerCheck.position, -transform.right, entityData.detectDistance, entityData.playerLayer);
    }
    
    public virtual bool CheckInAttackRange() {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.attackDistance, entityData.playerLayer) 
               || Physics2D.Raycast(playerCheck.position, -transform.right, entityData.attackDistance, entityData.playerLayer);
    }

    public virtual int PlayerDirection() {
        if (Physics2D.Raycast(playerCheck.position, transform.right, entityData.detectDistance,entityData.playerLayer)) {
            return 1;
        } else if (Physics2D.Raycast(playerCheck.position, -transform.right, entityData.detectDistance, entityData.playerLayer)) {
            return -1;
        }
        return 0;
    }

    public virtual void Flip() {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public void Death(Sprite deadSprite, float deathDelay) {
        if (animator.enabled) {
            Instantiate(heartPrefab, gameObject.transform.position, Quaternion.identity);
        }
        spriteRenderer.sprite = deadSprite;
        animator.enabled = false;
        Destroy(gameObject,deathDelay);
    }

    /*
    public void OnDrawGizmos() {
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.detectDistance));
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + (Vector3)(-Vector2.right * facingDirection * entityData.detectDistance));
    }*/
}
