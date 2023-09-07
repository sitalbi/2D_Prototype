using System;
using System.Collections;
using System.Collections.Generic;
using Props;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField]
    private int collectableLayer;
    
    [SerializeField]
    private string interactableTag, passageTag;

    [SerializeField] private string enemyTag;

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
        if (collision.gameObject.CompareTag(enemyTag)) {
            AttackDetails attackDetails = new AttackDetails();
            attackDetails.damageCost = 1;
            attackDetails.position = collision.transform.position;
            _playerDamage.Damage(attackDetails);
        } else if (collision.gameObject.layer == collectableLayer) {
            collision.gameObject.SendMessage("Collect");
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag(interactableTag)) {
            col.gameObject.SendMessage("PlayerInRange");
        }
        
        if (col.gameObject.CompareTag(passageTag)) {
            col.gameObject.SendMessage("ChangeLevel");
        }
    }
    
    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.CompareTag(interactableTag)) {
            col.gameObject.SendMessage("PlayerExitRange");
        }
    }
}
