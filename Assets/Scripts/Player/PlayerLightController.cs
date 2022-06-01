using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightController : MonoBehaviour
{
    [SerializeField] private GameObject playerLight, globalLight;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!globalLight.activeSelf) {
            playerLight.SetActive(true);
        }
        else {
            playerLight.SetActive(false);
        }
    }
}
