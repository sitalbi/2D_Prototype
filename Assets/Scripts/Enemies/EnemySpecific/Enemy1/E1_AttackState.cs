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
}
