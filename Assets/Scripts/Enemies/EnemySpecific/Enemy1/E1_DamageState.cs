﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_DamageState : DamageState
{
    
    private Enemy1 enemy;
    
    public E1_DamageState(Entity entity, FinalStateMachine stateMachine, string animBoolParameterName, 
        DamageStateData stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolParameterName, stateData) {
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