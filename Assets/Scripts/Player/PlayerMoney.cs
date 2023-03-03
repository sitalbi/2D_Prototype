using System;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{

    [SerializeField] 
    private PlayerData data;
    [SerializeField] 
    private Money moneyUI;
    
    private Rigidbody2D rg2D;
    
    private PlayerController _controller;

    private int coinsAmount;

    public int CoinsAmount
    {
        get { return coinsAmount; }
        set
        {
            coinsAmount = value;
            PlayerPrefs.SetInt("money", value);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rg2D = GetComponent<Rigidbody2D>();
        _controller = GetComponent<PlayerController>();
        
        if (!PlayerPrefs.HasKey("money"))
        {
            CoinsAmount = 0;
        }
        else
        {
            CoinsAmount = PlayerPrefs.GetInt("money");
            moneyUI.UpdateMoney(CoinsAmount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoneyIncrease(int amount) {
        CoinsAmount+=amount;
        moneyUI.UpdateMoney(CoinsAmount);
    }
    
    public void MoneyDecrease(int amount) {
        CoinsAmount-=amount;
        moneyUI.UpdateMoney(CoinsAmount);
    }
}
