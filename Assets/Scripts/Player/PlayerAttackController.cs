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
    [SerializeField] 
    private float attackRange;
    private float _nextAttackTime = 0f; 
    private float _nextAttackCounter = 0f; 
    
    private bool _gotInput;
    private bool canAttack;

    private int currentAttackCounter;
    private int attacksNumber = 2;
    
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        canAttack = true;
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
        if (_gotInput && canAttack) {
            //perform attack
            _gotInput = false;
            _animator.SetTrigger("Attack");
            _animator.SetInteger("attackCounter", currentAttackCounter);
            canAttack = false;
            _nextAttackCounter = Time.time + 1f/(attackRate);
        }
        else {
            _gotInput = false;
        }

        if (Time.time >= _nextAttackCounter)
        {
            currentAttackCounter = 0;
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

    private void AttackEnd()
    {
        if (currentAttackCounter < attacksNumber - 1)
        {
            currentAttackCounter++;
        }
        else
        {
            currentAttackCounter = 0;
        }

        canAttack = true;
    }
    
}
