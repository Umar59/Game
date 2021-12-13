using System;
using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        try     { slider = GetComponent<Slider>(); }
        catch   { Debug.Log("Failed to get Slider component"); }
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetCurrentHealth(int health)
    {
        slider.value = health;
    }
}
