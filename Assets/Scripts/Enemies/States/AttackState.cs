using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private AttackStateData stateData;

    private Transform attackPoint;

    private bool isAttackFinished;
    
    public AttackState(Entity entity, FinalStateMachine stateMachine, string animBoolParameterName, 
        AttackStateData stateData, Transform attackPoint) : base(entity, stateMachine, animBoolParameterName) {
            this.stateData = stateData;
            this.attackPoint = attackPoint;
    }

    public override void Enter() {
        base.Enter();

        isAttackFinished = false;
        entity.atsm._attackState = this;
        entity.SetVelocity(0f);
    }

    public override void Exit() {
        base.Exit();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
    
    public void TriggerAttack() {
        attackPoint.gameObject.SetActive(true);

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, stateData.attackRange, stateData.enemyLayers);

        float[] attackDetails = { stateData.damageCost, entity.transform.position.x };
        
        foreach (Collider2D collider in hitObjects) {
            collider.SendMessage("Damage", attackDetails);
        }
    }

    public void FinishAttack() {
        isAttackFinished = true;
    }
}
