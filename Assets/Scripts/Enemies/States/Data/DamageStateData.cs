using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDamageStateData", menuName = "Data/State_Data/Damage_State")]
public class DamageStateData : ScriptableObject
{
    public Vector2 knockback;
}
