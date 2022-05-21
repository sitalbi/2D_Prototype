using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float health;
    private SpriteRenderer _spriteRenderer;
    private float nextDamageTime = 0f;
    [SerializeField]
    private float invincibilityTime;
    private Rigidbody2D rg2D;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        rg2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < nextDamageTime) {
            _spriteRenderer.color = Color.grey;
        }
        else {
            _spriteRenderer.color = Color.white;
        }
    }
    
    public void takeDamage(float damageCost) {
        if (Time.time >= nextDamageTime) {
            health -= damageCost;
            nextDamageTime = Time.time + invincibilityTime;
            rg2D.AddForce(new Vector2(0, 50), ForceMode2D.Impulse);
        }
    }
}
