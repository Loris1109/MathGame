using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{

    public Slider fuelSlider;
    

    public void SetFuel(float fuel)
    {
        fuelSlider.value = fuel;
        
    }

    public void SetMaxFuel(float fuelCapasity)
    {
        fuelSlider.maxValue = fuelCapasity;
        fuelSlider.value = fuelCapasity;
    }
}
