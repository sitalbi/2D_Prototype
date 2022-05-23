using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/State_Data/Idle_State")]
public class IdleStateData : ScriptableObject
{
    public float minIdleTime = 1f;
    public float maxIdleTime = 2f;
    
}
