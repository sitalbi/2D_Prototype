using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int movementSpeed;
    [SerializeField] private int jumpForce;
    private Rigidbody2D rigidbody;
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * movementSpeed  * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space)) {
            rigidbody.AddForce(new Vector2(0,jumpForce)*100);
        }
        
        //Flip the sprite according to the direction
        if(Input.GetAxis("Horizontal") < 0 && facingRight)
        {
            FlipSprite();
        }

        if (Input.GetAxis("Horizontal") > 0 && !facingRight)
        {
            FlipSprite();
        }
    }
    
    private void FlipSprite()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
