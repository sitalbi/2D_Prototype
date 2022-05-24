using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAttackStateData", menuName = "Data/State_Data/Attack_State")]
public class AttackStateData : ScriptableObject
{
    public float damageCost = 1f;
    public float attackRange = 0.3f;
    public float attackCoolDown = 0.5f;

    public LayerMask enemyLayers;
}
