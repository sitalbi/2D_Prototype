using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeController : MonoBehaviour
{
    [SerializeField] 
    private float health;
    [SerializeField]
    private Sprite deadSprite;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private string deathAnimationName;
    [SerializeField]
    private int deadLayer;
    
    private Animator _animator;

    private bool _isDead = false;

    // Start is called before the first frame update
    void Start() {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    private void CheckHealth() {
        if (health <= 0) {
            Death();
        }
    }

    private void Death() {
        //Death
        gameObject.layer = deadLayer;
        _animator.Play(deathAnimationName);
        GetComponent<EnemyMovement>().enabled = false;
        Invoke("ChangeToDeadSprite", _animator.GetCurrentAnimatorStateInfo(0).length);
    }

    private void ChangeToDeadSprite() {
        spriteRenderer.sprite = deadSprite;
        _animator.enabled = false;
    }

    public void takeDamage(float damageCost) {
        _animator.SetTrigger("Damage");
        health -= damageCost;
    }
}
