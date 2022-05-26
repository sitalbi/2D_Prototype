using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public void SetMaxHealth(float health) {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health) {
        if (health < 0) {
            health = 0;
        }
        slider.value = health;
    }
}
