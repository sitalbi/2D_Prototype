using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private ChestManager chestManager;
    
    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().sprite = chestManager.chestData.item.GetComponent<SpriteRenderer>().sprite;
        transform.localScale = new Vector3(1, 1, 1);
        animator.Play("itemOut");
        Invoke(nameof(Finish), 1.5f);
        
    }

    private void Finish()
    {
        this.gameObject.SetActive(false);
    }
}
