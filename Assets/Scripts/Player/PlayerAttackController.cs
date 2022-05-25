using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] 
    private Transform attackPoint;
    [SerializeField] 
    private LayerMask enemyLayers;
    [SerializeField] 
    private float attackRate;
    [SerializeField] 
    private float _damageCost;
    
    private float attackRange = 0.6f;
    private float _nextAttackTime = 0f; 
    
    private bool _gotInput;
    
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCombatInputs();
        CheckAttack();
    }

    private void CheckCombatInputs() {
        if (Input.GetKeyDown(KeyCode.X)) {
            _gotInput = true;
        }
    }

    private void CheckAttack() {
        if (_gotInput && Time.time >= _nextAttackTime) {
            //perform attack
            _gotInput = false;
            _animator.SetTrigger("Attack");
            _nextAttackTime = Time.time + 1f/attackRate;
        }
        else {
            _gotInput = false;
        }
    }

    private void Attack() {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        AttackDetails attackDetails = new AttackDetails();
        attackDetails.damageCost = _damageCost;
        attackDetails.position = gameObject.transform.position;
        
        foreach (Collider2D hitObject in hitObjects) {
            hitObject.SendMessage("Damage", attackDetails);
        }
    }
    
}
