using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player_Data")]
public class PlayerData : ScriptableObject
{
    public float health = 5f;
    
    public float invincibilityTime = 0.5f;
    
    public int movementSpeed = 5;

    public float jumpForce = 7f;
    public float dashDuration = 0.1f;
    public float dashForce = 25f;
    public float dashCoolDown = 0.3f;
    
}
