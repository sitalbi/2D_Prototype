using System;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] 
    private PlayerData data;
    [SerializeField] 
    private Health healthBar;
    [SerializeField] 
    private Animator animator;
    
    private Rigidbody2D rg2D;
    
    private PlayerController _controller;

    private float damageDuration, damageStart, nextDamageTime;

    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        rg2D = GetComponent<Rigidbody2D>();
        _controller = GetComponent<PlayerController>();
        damageDuration = 0.3f;
        currentHealth = data.health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < nextDamageTime) {
            if (Time.time >= damageStart + damageDuration) {
                _controller.isDamage = false;
            }
        }
        else {
            _controller.isDamage = false;
        }
    }
    
    public void Damage(AttackDetails attackDetails) {
        if (Time.time >= nextDamageTime) {
            damageStart = Time.time;
            _controller.isDamage = true;
            animator.SetTrigger("Damage");
            float direction = transform.position.x - attackDetails.position.x;
            int knockbackDirection = direction > 0 ? 1 : -1;
            if (currentHealth > 0) {
                currentHealth -= attackDetails.damageCost;
            }
            rg2D.velocity = new Vector2((knockbackDirection * attackDetails.damageCost * 3), 0);
            nextDamageTime = Time.time + data.invincibilityTime;
            healthBar.SetHealth((int)currentHealth);
        }
    }

    public void HealthIncrease() {
        currentHealth+=1;
        healthBar.SetHealth((int)currentHealth);
    }
}
