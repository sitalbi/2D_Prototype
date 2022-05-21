using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float health;
    private Animator _animator;
    public bool isDead;
    
    // Start is called before the first frame update
    void Start() {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            //Death
            _animator.SetTrigger("Death");
            GetComponent<EnemyMovement>().enabled = false;
            Destroy(this.gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }

    public void takeDamage(float damageCost) {
        _animator.SetTrigger("Damage");
        health -= damageCost;
    }
}
