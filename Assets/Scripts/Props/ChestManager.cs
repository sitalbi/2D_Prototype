using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Props;
using UnityEngine;

public class ChestManager : Interactable
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject item;
    [SerializeField] private Sprite chestOpen, chestClose;

    private BoxCollider2D boxCollider;

    public override void Start()
    {
        base.Start();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected override void Interact()
    {
        Open();
    }

    private void Open()
    {
        animator.Play("chestOpening");
        boxCollider.enabled = false;
    }

    public void ChestOpened()
    {
        item.SetActive(true);
        GetComponent<SpriteRenderer>().sprite = chestOpen;
    }
}
