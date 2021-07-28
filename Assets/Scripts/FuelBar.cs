using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{

    public Slider slider;
    public Gradient Gradient;
    public Image fill;

    public bool Consumpsion;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 150;
    }

    public void SetFuel(int fuel)
    {
        slider.value = fuel;

    }
    // Update is called once per frame
    void Update()
    {
        if (!Consumpsion)
        {
            slider.value = Mathf.Lerp(slider.value, Crossroad.score, Time.deltaTime * 1);
        }
        else
        {
            slider.value -=2f ;

        }
        Gradient.Evaluate(1f);
        fill.color = Gradient.Evaluate(slider.normalizedValue);
    }
}
