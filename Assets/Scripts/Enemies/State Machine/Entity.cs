using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FinalStateMachine stateMachine;
    public EntityData entityData;
    public Rigidbody2D rigidbody { get; private set; }
    public Animator animator { get; private set; }
    public int facingDirection { get; private set; }

    [SerializeField] private Transform wallCheck, ledgeCheck;
    
    private Vector2 velocityVector;

    public virtual void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facingDirection = 1;

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

    public virtual bool CheckWall() {
        return Physics2D.Raycast(wallCheck.position, transform.right, entityData.wallCheckDistance,
            entityData.groundLayer);
    }
    
    public virtual bool CheckLedge() {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance,
            entityData.groundLayer);
    }

    public virtual void Flip() {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
