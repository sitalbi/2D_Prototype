using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rg2D;
    [SerializeField] 
    private Transform attackPoint;

    [SerializeField] private float attackRange;
    [SerializeField] 
    private LayerMask enemyLayers;
    [SerializeField] 
    private float attackRate;
    [SerializeField] 
    private float damageCost;
    private float nextAttackTime = 0f;
    private EnemyMovement _movement;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rg2D = GetComponent<Rigidbody2D>();
        _movement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update() {
        _movement.canMove = Time.time >= nextAttackTime;
        if (Time.time >= nextAttackTime) { 
            if (_movement.distanceFromPlayer <= 2f) {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f/attackRate;
            }
            else {
                attackPoint.gameObject.SetActive(false);
            }
        }
    }

    private void Attack() {
        attackPoint.gameObject.SetActive(true);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            enemy.gameObject.GetComponent<PlayerLife>().takeDamage(damageCost);
        }
    }
}
