using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected IdleStateData stateData;

    protected bool flipAfterIdle, isIdleTimeOver;

    protected float idleTime;

    public IdleState(Entity entity, FinalStateMachine stateMachine, string animBoolParameterName, IdleStateData stateData) : base(entity,
        stateMachine, animBoolParameterName) {
        this.stateData = stateData;
    }

    public override void Enter() {
        base.Enter();
        
        entity.SetVelocity(0f);
        isIdleTimeOver = false;
        SetRandomIdleTime();
    }

    public override void Exit() {
        base.Exit();

        if (flipAfterIdle) {
            entity.Flip();
        }
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        if (Time.time >= startTime + idleTime) {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }

    public void SetFlipAfterIdle(bool flip) {
        flipAfterIdle = flip;
    }

    private void SetRandomIdleTime() {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}

