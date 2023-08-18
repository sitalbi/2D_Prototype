using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using LDtkUnity;
using UnityEngine;

public class PassageManager : MonoBehaviour
{
    [SerializeField] private GameObject fromLevel, toLevel, player;

    public void ChangeLevel() {
        toLevel.SetActive(true);
        player.transform.position = toLevel.transform.Find("PlayerSpawn").position;
        
        fromLevel.SetActive(false);
    }
}
