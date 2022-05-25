using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageState : State
{
    protected DamageStateData stateData;

    protected bool isAnimationFinished, isDamageFinished;

    public AttackDetails attackDetails { get; set; }
    
    public DamageState(Entity entity, FinalStateMachine stateMachine, 
        string animBoolParameterName, DamageStateData stateData) : base(entity, stateMachine, animBoolParameterName) {
        this.stateData = stateData;
    }

    public override void Enter() {
        base.Enter();
        
        isDamageFinished = false;
        isAnimationFinished = false;
        // Compute the direction of the knockback using attackdetails position
        float position = entity.transform.position.x - attackDetails.position.x;
        int knockbackDirection = position > 0 ? 1 : -1;  
        Vector2 knockback = new Vector2(knockbackDirection * (attackDetails.damageCost * 5),attackDetails.damageCost * 2);
        entity.SetVelocity(knockback);
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


    public void FinishDamageAnimation() {
        isAnimationFinished = true;
    }
    public void FinishDamage() {
        isDamageFinished = true;
    }
}
