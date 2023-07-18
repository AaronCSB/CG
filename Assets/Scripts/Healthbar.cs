using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public Slider slider;

    public void setHealth(int hp) { 
        slider.value = hp; 
    }

    public void setMaxHealth(int hp)
    {
        slider.value = hp;
        slider.maxValue = hp;
    }
}
