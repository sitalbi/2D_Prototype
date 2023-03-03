using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    private PlayerMoney playerMoney;
    
        
    public override void Collect()
    {
        playerMoney = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoney>();
        playerMoney.MoneyIncrease(1);
        base.Collect();
    }
}
