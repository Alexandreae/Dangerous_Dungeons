using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_Vida : MonoBehaviour
{


    private int current;
    private int max;
    private double amount;
    public Slider slider;

    void Start()
    {
        current = GameManager.vida_max;
        max = GameManager.vida_max;
    }

    // Update is called once per frame
    void Update()
    {
        if (current != GameManager.vida) {

            current = GameManager.vida;
            amount = (double)current/max;
            slider.value = Convert.ToSingle(amount);
        }
    }
}
