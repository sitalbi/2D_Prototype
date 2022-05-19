using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float health;
    public bool isTakingDamage;
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
        }
    }

    public void takeDamage(float damageCost) {
        _animator.SetTrigger("Damage");
        health -= damageCost;
        isTakingDamage = true;
    }
}
