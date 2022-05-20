using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float health;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start() {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            //Death
            GetComponent<EnemyMovement>().enabled = false;
            _animator.Play("goblin_death");
            Destroy(this.gameObject, _animator.GetCurrentAnimatorStateInfo(0).length+0.5f);
        }
    }

    private void Death() {
        enabled = false;
    }

    public void takeDamage(float damageCost) {
        _animator.SetTrigger("Damage");
        health -= damageCost;
    }
}
