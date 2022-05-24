using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private AttackStateData stateData;

    private Transform attackPoint;

    protected bool isAnimationFinished, isPlayerInRange, isAttackFinished;

    protected AttackDetails attackDetails;
    private float animationFinishTime;

    public AttackState(Entity entity, FinalStateMachine stateMachine, string animBoolParameterName, 
        AttackStateData stateData, Transform attackPoint) : base(entity, stateMachine, animBoolParameterName) {
            this.stateData = stateData;
            this.attackPoint = attackPoint;
    }

    public override void Enter() {
        base.Enter();

        isAttackFinished = false;
        isAnimationFinished = false;
        entity.SetVelocity(0f);
        isPlayerInRange = entity.CheckInAttackRange();
    }

    public override void Exit() {
        base.Exit();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        if (isAnimationFinished) {
            if (Time.time >= animationFinishTime + stateData.attackCoolDown) {
                isAttackFinished = true;
            }
        }
        
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
        
        isPlayerInRange = entity.CheckInAttackRange();
    }
    
    public void TriggerAttack() {
        attackPoint.gameObject.SetActive(true);

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, stateData.attackRange, stateData.enemyLayers);

        attackDetails.position = entity.transform.position;
        attackDetails.damageCost = stateData.damageCost;
        
        foreach (Collider2D collider in hitObjects) {
            collider.SendMessage("Damage", attackDetails);
        }
    }

    public void FinishAttack() {
        isAnimationFinished = true;
        attackPoint.gameObject.SetActive(false);
        animationFinishTime = Time.time;
    }
}
