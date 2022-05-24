using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_FollowState : FollowState
{

    private Enemy1 enemy;
    
    public E1_FollowState(Entity entity, FinalStateMachine stateMachine, string animBoolParameterName, FollowStateData stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolParameterName, stateData) {
        this.enemy = enemy;
    }

    public override void Enter() {
        base.Enter();
    }

    public override void Exit() {
        base.Exit();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
        
        if (playerDetected) {
            if (enemy.PlayerDirection() == -1) {
                enemy.Flip();
            }
            if (inAttackRange) {
                entity.stateMachine.ChangeState(enemy.attackState);
            }
        }
        else {
            entity.stateMachine.ChangeState(enemy.idleState);
        }
        
    }
}
