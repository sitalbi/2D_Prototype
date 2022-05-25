using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageState : State
{
    private DamageStateData stateData;

    protected bool isDamageFinished;
    
    public AttackDetails attackDetails { private get; set; }
    
    public DamageState(Entity entity, FinalStateMachine stateMachine, 
        string animBoolParameterName, DamageStateData stateData) : base(entity, stateMachine, animBoolParameterName) {
        this.stateData = stateData;
    }

    public override void Enter() {
        base.Enter();
        
        isDamageFinished = false;
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


    public void FinishDamage() {
        isDamageFinished = true;
    }
}
