using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/EntityData/Base_Data")]
public class EntityData : ScriptableObject
{
   public float wallCheckDistance = 0.2f;
   public float ledgeCheckDistance = 0.4f;

   public float agroDistance = 3f;

   public LayerMask groundLayer, playerLayer;
}
