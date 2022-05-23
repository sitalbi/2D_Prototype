using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
   public E1_IdleState idleState { get; private set; }
   public E1_MoveState moveState { get; private set; }
   public E1_FollowState followState { get; private set; }

   [SerializeField] private IdleStateData idleStateData;
   [SerializeField] private MoveStateData moveStateData;
   [SerializeField] private FollowStateData followStateData;

   public override void Start() {
      base.Start();

      moveState = new E1_MoveState(this, stateMachine, "move", moveStateData, this);
      idleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
      followState = new E1_FollowState(this, stateMachine, "move", followStateData, this);
      
      stateMachine.Initialize(idleState);
   }
}
