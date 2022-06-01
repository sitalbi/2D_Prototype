using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    [SerializeField] private Sprite activated, nonActivated;
    [SerializeField] private GameObject light;

    private SpriteRenderer spriteRenderer;

    private bool isActivated;
    
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = light.activeSelf ? activated : nonActivated;
    }

    
    void Update()
    {
        
    }

    public void Damage() {
        isActivated = !isActivated;
        if (isActivated) {
            spriteRenderer.sprite = activated;
            light.SetActive(true);
        }
        else {
            spriteRenderer.sprite = nonActivated;
            light.SetActive(false);
        }
    }
}
