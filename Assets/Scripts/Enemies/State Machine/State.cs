using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected FinalStateMachine stateMachine;
    protected Entity entity;

    protected float startTime;

    protected string animBoolParameterName;

    public State(Entity entity, FinalStateMachine stateMachine, string animBoolParameterName) {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolParameterName = animBoolParameterName;
    }

    public virtual void Enter() {
        startTime = Time.time;
        entity.animator.SetBool(animBoolParameterName, true);
    }
    
    public virtual void Exit() {
        entity.animator.SetBool(animBoolParameterName, false);
    }
    
    public virtual void LogicUpdate() {
        
    }
    
    public virtual void PhysicsUpdate() {
        
    }
}
