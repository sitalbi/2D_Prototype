using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageState : State
{
    private DamageStateData stateData;

    private bool isTakingDamage;

    private float animationTime;
    
    public AttackDetails attackDetails { private get; set; }
    
    public DamageState(Entity entity, FinalStateMachine stateMachine, 
        string animBoolParameterName, DamageStateData stateData) : base(entity, stateMachine, animBoolParameterName) {
        this.stateData = stateData;
    }

    public override void Enter() {
        base.Enter();

        // Compute the direction of the knockback using attackdetails position
        isTakingDamage = true;
        Vector2 knockback = new Vector2(attackDetails.damageCost * 3,attackDetails.damageCost * 2);
        entity.SetVelocity(knockback);
    }

    public override void Exit() {
        base.Exit();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        if (Time.time >= startTime + animationTime) {
            isTakingDamage = false;
            
        }

        if(animationTime!=0) animationTime = entity.animator.GetCurrentAnimatorStateInfo(0).length;
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }

    
}
