using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement _playerMovement;
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
        _playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime) {
            _playerMovement.reducedSpeed = 1f;
            if (Input.GetKeyDown(KeyCode.X)) {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f/attackRate;
            }
        }
        else {
            _playerMovement.reducedSpeed = 0.3f;
        }
    }

    private void Attack() {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            enemy.gameObject.GetComponent<EnemyLife>().takeDamage(damageCost);
        }
    }
    
}
