using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_DeadState : DeadState
{
    private Enemy1 enemy;

    public E1_DeadState(Entity entity, FinalStateMachine stateMachine, string animBoolParameterName, 
        DeadStateData stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolParameterName, stateData) {
        this.enemy = enemy;
    }

    public override void Enter() {
        base.Enter();

        entity.atsm._deadsState = this;
        enemy.SetVelocity(0f);
    }

    public override void Exit() {
        base.Exit();
    }
    
    public override void LogicUpdate() {
        base.LogicUpdate();

        if (isAnimationFinished) {
            entity.Death(stateData.deadSprite, stateData.deadLayerValue, stateData.deathDelay);
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
}
