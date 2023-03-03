using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    [SerializeField] private ChestData chestData;
    [SerializeField] private Animator animator;
    
    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().sprite = chestData.item.GetComponent<SpriteRenderer>().sprite;
        animator.Play("itemOut");
        Invoke(nameof(Finish), 1.5f);
        
    }

    private void Finish()
    {
        this.gameObject.SetActive(false);
    }
}
