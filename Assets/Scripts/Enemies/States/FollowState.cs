using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    private FollowStateData stateData;
    protected bool isFollowing, playerDetected;

    public FollowState(Entity entity, FinalStateMachine stateMachine, string animBoolParameterName, FollowStateData stateData) : base(entity, stateMachine, animBoolParameterName) {
        this.stateData = stateData;
    }

    public override void Enter() {
        base.Enter();
        
        entity.SetVelocity(stateData.movementSpeed);
        isFollowing = true;
    }

    public override void Exit() {
        base.Exit();

        isFollowing = false;
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
        playerDetected = entity.CheckInAgroRange();
        
        entity.SetVelocity(stateData.movementSpeed);
    }
}
