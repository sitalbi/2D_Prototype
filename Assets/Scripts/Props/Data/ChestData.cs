using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newChestData", menuName = "Data/Props/Chest_Data")]
public class ChestData : ScriptableObject
{
    public GameObject item; // the prefab of the object or item contained in the chest

    public bool isOpened;
}
