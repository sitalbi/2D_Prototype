using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float health;
    private SpriteRenderer _spriteRenderer;
    private float nextDamageTime = 0f;
    [SerializeField]
    private float invincibilityTime;
    private Rigidbody2D rg2D;
    private PlayerController _controller;
    public bool isDamage = false;
    private float damageDuration, damageStart;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        rg2D = GetComponent<Rigidbody2D>();
        _controller = GetComponent<PlayerController>();
        damageDuration = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < nextDamageTime) {
            _spriteRenderer.color = Color.grey;
            if (Time.time >= damageStart + damageDuration) {
                _controller.isDamage = false;
            }
        }
        else {
            _spriteRenderer.color = Color.white;
            _controller.isDamage = false;
        }
    }
    
    public void Damage(AttackDetails attackDetails) {
        if (Time.time >= nextDamageTime) {
            damageStart = Time.time;
            _controller.isDamage = true;
            float direction = transform.position.x - attackDetails.position.x;
            int knockbackDirection = direction > 0 ? 1 : -1;
            health -= attackDetails.damageCost;
            rg2D.velocity = new Vector2((knockbackDirection * attackDetails.damageCost * 3), attackDetails.damageCost*2);
            nextDamageTime = Time.time + invincibilityTime;
        }
    }
}
