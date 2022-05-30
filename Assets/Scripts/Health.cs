using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private Image[] images = new Image[5];
    [SerializeField]
    private Sprite fullHeart, emptyHeart;

    private void Start() {
        for (int i = 0; i < images.Length; i++) {
            images[i].sprite = fullHeart;
        }
    }

    public void SetMaxHealth(int health) {
        images = new Image[6];
        for (int i = 0; i < health; i++) {
            images[i].sprite = fullHeart;
        }
    }

    public void SetHealth(int health) {
        if (health < 0) {
            health = 0;
        }
        for (int i = health; i < images.Length; i++) {
            images[i].sprite = emptyHeart;
        }
    }
}
