using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDeadStateData", menuName = "Data/State_Data/Dead_State")]
public class DeadStateData : ScriptableObject
{
    public Sprite deadSprite;

    public float deathDelay = 3f;

    public int deadLayerValue = 11;
}
