using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    int DeathCounter = 0;



    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        
        fill.color = gradient.Evaluate(1f);

    }

   public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void Death()
    {
        DeathCounter++;
        if (DeathCounter == 1)
        {
            Heart1.color = Color.black;
        }
        else if (DeathCounter == 2)
        {
            Heart2.color = Color.black;
        }
        else if (DeathCounter == 3)
        {
            Heart3.color = Color.black;
        }

        //final death

    }
}
