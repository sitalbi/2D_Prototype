using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] 
    private Transform player;
    [SerializeField]
    private int movementSpeed;

    [NonSerialized]
    public float distanceFromPlayer;

    private Animator animator;
    public Rigidbody2D rigidbody;
    private bool facingRight = true;
    private int playerWay;
    public bool canMove;
    private bool inRange;

    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        distanceFromPlayer = Mathf.Abs(player.position.x - transform.position.x);
    }

    // Update is called once per frame
    void Update() {
        distanceFromPlayer = Mathf.Abs(player.position.x - transform.position.x);
        inRange = distanceFromPlayer <=8f && distanceFromPlayer>=2f;
        if(inRange) {
            playerWay = player.position.x - transform.position.x > 0 ? 1 : -1;
        }
        else {
            playerWay = 0;
        }

        //Flip the sprite according to the direction
        if (playerWay < 0 && facingRight) {
            FlipSprite();
        }

        if (playerWay > 0 && !facingRight) {
            FlipSprite();
        }

        AnimatorManagement();
    }

    private void FixedUpdate() {
        if (canMove && inRange && rigidbody.velocity.y == 0) {
            rigidbody.velocity = new Vector2(movementSpeed * playerWay, rigidbody.velocity.y);
        }
        else {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
    }

    private void FlipSprite() {
        // Switch the way the enemy is facing.
        facingRight = !facingRight;

        // Multiply the enemy's x local scale by -1.
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void AnimatorManagement() {
        animator.SetFloat("horizontalVelocity", Mathf.Abs(rigidbody.velocity.x));
        animator.SetFloat("verticalVelocity", rigidbody.velocity.y);
    }
}