using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Animation openingAnimation;
    [SerializeField] private ChestData chestData;
    
    private void Open()
    {
        openingAnimation.Play();
    }
}
