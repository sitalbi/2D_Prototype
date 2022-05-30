using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Collectable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Collect(PlayerLife playerLife) {
        playerLife.HealthIncrease();
        base.Collect(playerLife);
    }
}
