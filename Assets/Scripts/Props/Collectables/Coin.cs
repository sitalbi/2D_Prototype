using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    [SerializeField] private PlayerMoney playerMoney;
        
    public override void Collect()
    {
        playerMoney.MoneyIncrease(1);
        base.Collect();
    }
}
