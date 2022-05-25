using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
   public E1_IdleState idleState { get; private set; }
   public E1_MoveState moveState { get; private set; }
   public E1_FollowState followState { get; private set; }
   public E1_AttackState attackState { get; private set; }
   public E1_DamageState damageState { get; private set; }
   public E1_DeadState deadState { get; private set; }

   [SerializeField] private IdleStateData idleStateData;
   [SerializeField] private MoveStateData moveStateData;
   [SerializeField] private FollowStateData followStateData;
   [SerializeField] private AttackStateData attackStateData;
   [SerializeField] private DamageStateData damageStateData;
   [SerializeField] private DeadStateData deadStateData;

   [SerializeField] private Transform attackPoint;

   public override void Start() {
      base.Start();

      moveState = new E1_MoveState(this, stateMachine, "move", moveStateData, this);
      idleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
      followState = new E1_FollowState(this, stateMachine, "move", followStateData, this);
      attackState = new E1_AttackState(this, stateMachine, "attack", attackStateData, this, attackPoint);
      damageState = new E1_DamageState(this, stateMachine, "damage", damageStateData, this);
      deadState = new E1_DeadState(this, stateMachine, "death", deadStateData, this);
      
      stateMachine.Initialize(idleState);
   }
   
   public void Damage(AttackDetails attackDetails) {
      damageState.attackDetails = attackDetails;
      stateMachine.ChangeState(damageState);
   }
}
