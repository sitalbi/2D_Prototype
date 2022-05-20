using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int movementSpeed;

    private Animator animator;
    private Rigidbody2D rigidbody;
    private bool facingRight = true;
    private int playerWay;
    private bool canMove;

    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Mathf.Abs(player.position.x - transform.position.x) <= 8f &&
            Mathf.Abs(player.position.x - transform.position.x) >= 2f) {
            playerWay = player.position.x - transform.position.x > 0 ? 1 : -1;
            canMove = rigidbody.velocity.y == 0;
        }
        else {
            playerWay = 0;
            canMove = false;
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
        if (canMove) {
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