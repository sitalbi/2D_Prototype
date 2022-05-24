using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/EntityData/Base_Data")]
public class EntityData : ScriptableObject
{
   public float wallCheckDistance = 0.2f;
   public float ledgeCheckDistance = 0.4f;

   public float detectDistance = 3f;
   public float attackDistance = 1f;

   public LayerMask groundLayer, playerLayer;
}
