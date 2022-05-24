using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_AttackState : AttackState
{
    private Enemy1 enemy;
    
    public E1_AttackState(Entity entity, FinalStateMachine stateMachine, string animBoolParameterName, 
        AttackStateData stateData, Enemy1 enemy, Transform attackPoint) : base(entity, stateMachine, animBoolParameterName, stateData, attackPoint) {
        this.enemy = enemy;
    }

    public override void Enter() {
        base.Enter();
        
        entity.atsm._attackState = this;
    }

    public override void Exit() {
        base.Exit();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        if (isAttackFinished) {
            if (isPlayerInRange) {
                stateMachine.ChangeState(enemy.followState);
            }
            else {
                stateMachine.ChangeState(enemy.moveState);
            }
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
}
