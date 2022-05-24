using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateData : ScriptableObject
{
    public float damageCost = 1f;
    public float attackRange = 0.3f;

    public LayerMask enemyLayers;
}
