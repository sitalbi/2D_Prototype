using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField]
    private int enemyLayer;

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
        if (collision.gameObject.layer == enemyLayer) {
            _playerDamage.takeDamage(1);
        } 
    }
}
