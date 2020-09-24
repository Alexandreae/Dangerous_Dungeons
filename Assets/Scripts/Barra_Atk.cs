using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_Atk : MonoBehaviour
{


    private float current;
    private float max;
    private float amount;
    public Slider slider;

    void Start()
    {
        current = GameManager.cd_atk_max;
        max = GameManager.cd_atk_max;
    }

    // Update is called once per frame
    void Update()
    {
        if (current != GameManager.cd_atk) {
            current = GameManager.cd_atk;
            amount = current/max;
            slider.value = amount;
        }
    }
}
