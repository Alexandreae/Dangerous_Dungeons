using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_Def : MonoBehaviour
{


    private float current;
    private float max;
    private float amount;
    public Slider slider;

    void Start()
    {
        current = GameManager.cd_def_max;
        max = GameManager.cd_def_max;
    }

    // Update is called once per frame
    void Update()
    {
        if (current != GameManager.cd_def) {
            current = GameManager.cd_def;
            amount = current/max;
            slider.value = amount;
        }
    }
}
