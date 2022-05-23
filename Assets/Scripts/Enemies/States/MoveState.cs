using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected MoveStateData stateData;

    protected bool isDetectingWall, isDetectingLedge, isDetectingPlayer;

    public MoveState(Entity entity, FinalStateMachine stateMachine, string animBoolParameterName,
        MoveStateData stateData) : base(entity, stateMachine, animBoolParameterName) {
        this.stateData = stateData;
    }

    public override void Enter() {
        base.Enter();
        entity.SetVelocity((stateData.movementSpeed));

        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isDetectingPlayer = entity.CheckInAgroRange();
    }

    public override void Exit() {
        base.Exit();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
        
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isDetectingPlayer = entity.CheckInAgroRange();
    }
}
