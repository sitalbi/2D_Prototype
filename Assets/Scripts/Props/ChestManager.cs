using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject item;
    [SerializeField] private Sprite chestOpen, chestClose;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Open();
        }
    }
    
    private void Open()
    {
        animator.Play("chestOpening");
    }

    public void ChestOpened()
    {
        item.SetActive(true);
    }
}
