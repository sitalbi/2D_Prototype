using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField]
    private int enemiesLayer, propsLayer;

    [SerializeField] 
    private int tilemapLayer;

    private PlayerLife _playerDamage;
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start() {
        _playerDamage = GetComponent<PlayerLife>();
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == enemiesLayer) {
            AttackDetails attackDetails = new AttackDetails();
            attackDetails.damageCost = 1;
            attackDetails.position = collision.transform.position;
            _playerDamage.Damage(attackDetails);
        } 
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.layer == propsLayer) {
            col.gameObject.SendMessage("PlayerInRange");
        }
    }
    
    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.layer == propsLayer) {
            col.gameObject.SendMessage("PlayerExitRange");
        }
    }
}
