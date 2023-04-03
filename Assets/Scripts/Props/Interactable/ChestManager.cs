using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Props;
using UnityEngine;

public class ChestManager : Interactable
{
    [SerializeField] public ChestData chestData;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject itemPrefab;
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
        GameObject item = Instantiate(chestData.item, transform.position, Quaternion.identity);
        item.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,0.7f), ForceMode2D.Impulse);
    }
}
