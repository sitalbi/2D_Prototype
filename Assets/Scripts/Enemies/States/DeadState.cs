using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    protected DeadStateData stateData;
    protected bool isAnimationFinished, isDead; 
    
    public DeadState(Entity entity, FinalStateMachine stateMachine, 
        string animBoolParameterName, DeadStateData stateData) : base(entity, stateMachine, animBoolParameterName) {
        this.stateData = stateData;
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
    }

    public void FinishDeathAnimation() {
        isAnimationFinished = true;
    }
}
