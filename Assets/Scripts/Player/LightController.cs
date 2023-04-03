using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private GameObject localLight, globalLight;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!globalLight.activeSelf) {
            localLight.SetActive(true);
        }
        else {
            localLight.SetActive(false);
        }
    }
}
