using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    [SerializeField] 
    private Transform attackPoint;
    private float attackRange = 0.6f;
    [SerializeField] 
    private LayerMask enemyLayers;
    [SerializeField] 
    private float attackRate;
    [SerializeField] 
    private float damageCost;
    private float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime) {
            if (Input.GetKeyDown(KeyCode.X)) {
                Attack();
            }
        }
    }

    private void Attack() {
        animator.SetTrigger("Attack");
        nextAttackTime = Time.time + 1f/attackRate;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            enemy.gameObject.GetComponent<EnemyLife>().takeDamage(damageCost);
        }
    }
    
}
