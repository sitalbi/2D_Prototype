using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : MoveState
{
    private Enemy1 enemy;
    
    public E1_MoveState(Entity entity, FinalStateMachine stateMachine, string animBoolParameterName, MoveStateData stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolParameterName, stateData) {
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

        if (isDetectingWall || !isDetectingLedge) {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }

        if (isDetectingPlayer) {
            stateMachine.ChangeState(enemy.followState);
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
}
