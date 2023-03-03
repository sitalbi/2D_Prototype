﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private PlayerStats playerStats;
    
    private void Start() {
        
    }

    public void UpdateMoney(int amount)
    {
        coinText.text = amount.ToString();
    }
}
