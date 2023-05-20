using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider healtSlider;

    public void setHealth(int health)
    {
        healtSlider.value = health;
    }

    public void setMaxHealth(int health)
    {
        healtSlider.maxValue = health;
        healtSlider.value = health;
    }
}
