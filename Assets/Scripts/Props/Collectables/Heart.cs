using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Collectable
{
    private PlayerLife playerLife;

    private void Start()
    {
         playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }

    public override void Collect() {
        playerLife.HealthIncrease();
        base.Collect();
    }
}
